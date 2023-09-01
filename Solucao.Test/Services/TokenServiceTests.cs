﻿using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Moq;
using Solucao.Application.Contracts;
using Solucao.Application.Service.Implementations;
using Xunit;

namespace Solucao.Tests
{
    public class TokenServiceTests
    {
        [Fact]
        public void GenerateToken_WithValidUser_ReturnsToken()
        {
            // Arrange
            var tokenService = new TokenService();
            var user = new UserViewModel { Name = "John Doe" };

            // Act
            var token = tokenService.GenerateToken(user);

            // Assert
            Assert.NotNull(token);

            // Parse the token to ensure it's a valid token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("c29sdWNhby1sYXNlcg==");
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };

            var claimsPrincipal = tokenHandler.ValidateToken(token, validationParameters, out var validatedToken);
            var jwtToken = validatedToken as JwtSecurityToken;

            Assert.NotNull(claimsPrincipal);
            Assert.True(jwtToken.ValidTo > DateTime.UtcNow);
            Assert.Equal("John Doe", claimsPrincipal.FindFirstValue(ClaimTypes.Name));
        }

        [Fact]
        public void GenerateToken_WithNullUser_ReturnsNull()
        {
            // Arrange
            var tokenService = new TokenService();
            UserViewModel user = null;

            // Act
            var token = tokenService.GenerateToken(user);

            // Assert
            Assert.Null(token);
        }
    }
}
