insert into AttributeTypes ([key], [value]) VALUES ('Texto','string')
insert into AttributeTypes ([key], [value]) VALUES ('Data','datetime')
insert into AttributeTypes ([key], [value]) VALUES ('Hora','time')
insert into AttributeTypes ([key], [value]) VALUES ('Decimal','decimal')
insert into AttributeTypes ([key], [value]) VALUES ('Decimal Extenso','decimal_extenso')
insert into AttributeTypes ([key], [value]) VALUES ('Data Extenso','datetime_extenso')
insert into AttributeTypes ([key], [value]) VALUES ('Hora Extenso','time_extenso')

insert into TechnicalAttributes ([key], [value]) VALUES ('Hora Início','StartTime')
insert into TechnicalAttributes ([key], [value]) VALUES ('Hora Término','EndTime')
insert into TechnicalAttributes ([key], [value]) VALUES ('Nome Locatário','Client.Name')
insert into TechnicalAttributes ([key], [value]) VALUES ('Nome Equipamento','Equipament.Name')
insert into TechnicalAttributes ([key], [value]) VALUES ('Data Locação','Date')
insert into TechnicalAttributes ([key], [value]) VALUES ('Valor','Value')
insert into TechnicalAttributes ([key], [value]) VALUES ('Tempo Locação','RentalTime')
insert into TechnicalAttributes ([key], [value]) VALUES ('Ponteira1','Additional1')
insert into TechnicalAttributes ([key], [value]) VALUES ('Valor Sem Ponteira','ValueWithoutSpec')

insert into ModelAttributes (id,fileAttribute,technicalAttribute,AttributeType) VALUES ('ca1b62d3-30c1-4df9-8297-2116f8a96e5e','#HoraInicio', 'StartTime', 'time')
insert into ModelAttributes (id,fileAttribute,technicalAttribute,AttributeType) VALUES ('43644b11-9150-4c58-81ac-3640b42ac473','#HoraTermino', 'EndTime', 'time')
insert into ModelAttributes (id,fileAttribute,technicalAttribute,AttributeType) VALUES ('01ea2b18-04bf-4588-9925-4bec23d3756b','#NomeLocatario', 'Client.Name', 'string')
insert into ModelAttributes (id,fileAttribute,technicalAttribute,AttributeType) VALUES ('c8e5d713-5c71-45c7-b2af-b758619c310c','#DataLocacaoExtenso', 'Date', 'datetime_extenso')
insert into ModelAttributes (id,fileAttribute,technicalAttribute,AttributeType) VALUES ('af53bf1d-de2f-44d3-86f9-fc6d1323eec6','#ValorLocacaoExtenso', 'Value', 'decimal_extenso')
insert into ModelAttributes (id,fileAttribute,technicalAttribute,AttributeType) VALUES ('6671d7da-8829-4638-8332-fecb9bf6694b','#ValorLocacao', 'Value', 'decimal')
insert into ModelAttributes (id,fileAttribute,technicalAttribute,AttributeType) VALUES ('2c8d7537-f33f-419b-84b0-87c73ce233b4','#DataLocacao', 'Date', 'datetime')

insert into ModelAttributes (id,fileAttribute,technicalAttribute,AttributeType) VALUES ('6fb52746-a866-40e1-a8f4-53640bf15858','#TipoDocumento', 'Client.DocumentType', 'string')
insert into ModelAttributes (id,fileAttribute,technicalAttribute,AttributeType) VALUES ('7a8e7506-3630-42bc-bd55-90ae7cf54010','#LocatarioDocumento', 'Client.Document', 'string')
insert into ModelAttributes (id,fileAttribute,technicalAttribute,AttributeType) VALUES ('e9adc18e-5886-460d-85af-4c223c24d1e4','#LocatarioResponsavel', 'Client.Responsible', 'string')
insert into ModelAttributes (id,fileAttribute,technicalAttribute,AttributeType) VALUES ('cd5a1630-1803-45ce-903d-28741d17e456','#LocatarioNomeClinica', 'Client.ClinicName', 'string')

insert into ModelAttributes (id,fileAttribute,technicalAttribute,AttributeType) VALUES ('5c0aa420-5ac5-49b0-bcf4-aed0086964e1','#LocatarioEndereco', 'Client.FullAddress', 'string')
insert into ModelAttributes (id,fileAttribute,technicalAttribute,AttributeType) VALUES ('c4ec81a5-d5f8-479e-bc06-2a2d80d60ec6','#LocatarioCEP', 'Client.ZipCode', 'string')
insert into ModelAttributes (id,fileAttribute,technicalAttribute,AttributeType) VALUES ('721f4a4b-bf57-44a3-8603-2ad5912b4bff','#LocatarioPontoReferencia', 'Client.LandMark', 'string')
insert into ModelAttributes (id,fileAttribute,technicalAttribute,AttributeType) VALUES ('aab60812-3780-4aad-81a9-d6a9607a71d2','#LocatarioFixo', 'Client.Phone', 'string')
insert into ModelAttributes (id,fileAttribute,technicalAttribute,AttributeType) VALUES ('c9d39995-52b1-4502-9932-ef2eea29a26d','#LocatarioCelularClinica', 'Client.ClinicCellPhone', 'string')
insert into ModelAttributes (id,fileAttribute,technicalAttribute,AttributeType) VALUES ('a0a554c5-c159-4ae8-bda3-53065299bebb','#LocatarioEmail', 'Client.Email', 'string')
insert into ModelAttributes (id,fileAttribute,technicalAttribute,AttributeType) VALUES ('8c61c361-decd-446d-a034-924a2a8000a7','#LocatarioEscada', 'Client.HasStairs', 'boolean')
insert into ModelAttributes (id,fileAttribute,technicalAttribute,AttributeType) VALUES ('44e82855-04e9-4039-86f5-e28de962cd7b','#LocatarioArCondicionado', 'Client.HasAirConditioning', 'boolean')






