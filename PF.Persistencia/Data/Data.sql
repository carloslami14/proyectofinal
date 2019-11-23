/*
	Project: Plataforma Online para gestión de obras y proyectos de arquitectura o Ingeniería
	Date: 02/11/2019
*/

BEGIN
	--INSERT FAMILIES
	IF NOT EXISTS (SELECT * FROM Families)
		BEGIN
			PRINT 'INSERT UNITS'
			INSERT INTO Families([Name],[ModificationDate],[State])
			VALUES('ACEROS - HIERROS - OTROS METALES', GETDATE(), 1);

			INSERT INTO Families([Name],[ModificationDate],[State])
			VALUES('ADITIVOS - PEGAMENTOS - FIJACIONES', GETDATE(), 1);

			INSERT INTO Families([Name],[ModificationDate],[State])
			VALUES('AGLOMERANTES - PREMEZCLADOS', GETDATE(), 1);

			INSERT INTO Families([Name],[ModificationDate],[State])
			VALUES('AISLANTES', GETDATE(), 1);

			INSERT INTO Families([Name],[ModificationDate],[State])
			VALUES('ARIDOS', GETDATE(), 1);

			INSERT INTO Families([Name],[ModificationDate],[State])
			VALUES('CARPINTERIAS Y ACCESORIOS', GETDATE(), 1);

			INSERT INTO Families([Name],[ModificationDate],[State])
			VALUES('CHAPAS - ZINGUERIA - FILIGRANAS', GETDATE(), 1);

			INSERT INTO Families([Name],[ModificationDate],[State])
			VALUES('CONDUCTOS PARA FLUIDOS Y ACCESORIOS', GETDATE(), 1);

			INSERT INTO Families([Name],[ModificationDate],[State])
			VALUES('CONTENEDORES - FLETES', GETDATE(), 1);

			INSERT INTO Families([Name],[ModificationDate],[State])
			VALUES('ELEVADORES - PLATAFORMAS GIRATORIAS', GETDATE(), 1);

			INSERT INTO Families([Name],[ModificationDate],[State])
			VALUES('EQUIPAMIENTOS', GETDATE(), 1);

			INSERT INTO Families([Name],[ModificationDate],[State])
			VALUES('EQUIPOS', GETDATE(), 1);

			INSERT INTO Families([Name],[ModificationDate],[State])
			VALUES('INSTALACION DE GAS', GETDATE(), 1);

			INSERT INTO Families([Name],[ModificationDate],[State])
			VALUES('INSTALACION ELECTRICA -TELEFONIA - VIDEO', GETDATE(), 1);

			INSERT INTO Families([Name],[ModificationDate],[State])
			VALUES('INSTALACION SANITARIA', GETDATE(), 1);

			INSERT INTO Families([Name],[ModificationDate],[State])
			VALUES('INSTALACIONES CONTRA INCENDIOS', GETDATE(), 1);

			INSERT INTO Families([Name],[ModificationDate],[State])
			VALUES('LADRILLOS - BLOQUES - REFRACTARIOS', GETDATE(), 1);

			INSERT INTO Families([Name],[ModificationDate],[State])
			VALUES('MADERAS', GETDATE(), 1);

			INSERT INTO Families([Name],[ModificationDate],[State])
			VALUES('MANO DE OBRA', GETDATE(), 1);

			INSERT INTO Families([Name],[ModificationDate],[State])
			VALUES('PIEDRAS NATURALES', GETDATE(), 1);

			INSERT INTO Families([Name],[ModificationDate],[State])
			VALUES('PINTURAS - LUSTRES', GETDATE(), 1);

			INSERT INTO Families([Name],[ModificationDate],[State])
			VALUES('PISOS - ZOCALOS', GETDATE(), 1);

			INSERT INTO Families([Name],[ModificationDate],[State])
			VALUES('PLASTICOS', GETDATE(), 1);

			INSERT INTO Families([Name],[ModificationDate],[State])
			VALUES('PREFABRICADOS Y ACCESORIOS', GETDATE(), 1);

			INSERT INTO Families([Name],[ModificationDate],[State])
			VALUES('REVESTIMIENTOS', GETDATE(), 1);

			INSERT INTO Families([Name],[ModificationDate],[State])
			VALUES('TEJAS - TEJUELAS', GETDATE(), 1);

			INSERT INTO Families([Name],[ModificationDate],[State])
			VALUES('TERMINACIONES - JARDINERIA', GETDATE(), 1);

			INSERT INTO Families([Name],[ModificationDate],[State])
			VALUES('VIDRIOS - POLICARBONATOS', GETDATE(), 1);

			INSERT INTO Families([Name],[ModificationDate],[State])
			VALUES('VIGUETAS - BOVEDILLAS - POSTES', GETDATE(), 1);
		END

	-- INSERT FAMILIES
	IF NOT EXISTS (SELECT * FROM Units)
		BEGIN
			PRINT 'INSERT FAMILIES'
			INSERT INTO Units([Name],[Abbreviation],[ModificationDate],[State])
			VALUES('BARRA', 'BA', GETDATE(), 1);

			INSERT INTO Units([Name],[Abbreviation],[ModificationDate],[State])
			VALUES('BOLSA', 'BL', GETDATE(), 1);

			INSERT INTO Units([Name],[Abbreviation],[ModificationDate],[State])
			VALUES('CADA UNO', 'CU', GETDATE(), 1);

			INSERT INTO Units([Name],[Abbreviation],[ModificationDate],[State])
			VALUES('CAJA O CAJON', 'CJ', GETDATE(), 1);

			INSERT INTO Units([Name],[Abbreviation],[ModificationDate],[State])
			VALUES('CENTIMETRO', 'Cm', GETDATE(), 1);

			INSERT INTO Units([Name],[Abbreviation],[ModificationDate],[State])
			VALUES('CENTIMETRO CUADRADO', 'Cm2', GETDATE(), 1);

			INSERT INTO Units([Name],[Abbreviation],[ModificationDate],[State])
			VALUES('CENTIMETRO CUBICO', 'Cm3', GETDATE(), 1);

			INSERT INTO Units([Name],[Abbreviation],[ModificationDate],[State])
			VALUES('GRAMO', 'GR', GETDATE(), 1);

			INSERT INTO Units([Name],[Abbreviation],[ModificationDate],[State])
			VALUES('HORAS', 'HS', GETDATE(), 1);

			INSERT INTO Units([Name],[Abbreviation],[ModificationDate],[State])
			VALUES('KILOGRAMO', 'KG', GETDATE(), 1);

			INSERT INTO Units([Name],[Abbreviation],[ModificationDate],[State])
			VALUES('LATA', 'LA', GETDATE(), 1);

			INSERT INTO Units([Name],[Abbreviation],[ModificationDate],[State])
			VALUES('LITRO', 'LT', GETDATE(), 1);

			INSERT INTO Units([Name],[Abbreviation],[ModificationDate],[State])
			VALUES('METRO CUADRADO', 'M2', GETDATE(), 1);

			INSERT INTO Units([Name],[Abbreviation],[ModificationDate],[State])
			VALUES('METRO CUBICO', 'M3', GETDATE(), 1);

			INSERT INTO Units([Name],[Abbreviation],[ModificationDate],[State])
			VALUES('METRO LINEAL', 'ML', GETDATE(), 1);

			INSERT INTO Units([Name],[Abbreviation],[ModificationDate],[State])
			VALUES('PIE', 'PL', GETDATE(), 1);

			INSERT INTO Units([Name],[Abbreviation],[ModificationDate],[State])
			VALUES('PIE CUADRADO', 'P2', GETDATE(), 1);

			INSERT INTO Units([Name],[Abbreviation],[ModificationDate],[State])
			VALUES('PULGADA', 'PG', GETDATE(), 1);

			INSERT INTO Units([Name],[Abbreviation],[ModificationDate],[State])
			VALUES('ROLLO', 'RL', GETDATE(), 1);

			INSERT INTO Units([Name],[Abbreviation],[ModificationDate],[State])
			VALUES('TAMBOR', 'TB', GETDATE(), 1);

			INSERT INTO Units([Name],[Abbreviation],[ModificationDate],[State])
			VALUES('TONELADA', 'TN', GETDATE(), 1);
		END

	-- INSERT CATEGORIES
	IF NOT EXISTS (SELECT * FROM Categories)
	BEGIN
		PRINT 'INSERT CATEGORIES'
		BEGIN /*INSERT CATEGORIES WHERE FAMILY NAME IS 'ACEROS - HIERROS - OTROS METALES'*/
			INSERT INTO Categories([Name], [ModificationDate], [State], [FamilyId])
			VALUES('ALAMBRES', GETDATE(), 1, (SELECT Id FROM Families WHERE [Name] = 'ACEROS - HIERROS - OTROS METALES'));

			INSERT INTO Categories([Name], [ModificationDate], [State], [FamilyId])
			VALUES('CLAVOS', GETDATE(), 1, (SELECT Id FROM Families WHERE [Name] = 'ACEROS - HIERROS - OTROS METALES'));

			INSERT INTO Categories([Name], [ModificationDate], [State], [FamilyId])
			VALUES('HIERROS REDONDOS LISOS', GETDATE(), 1, (SELECT Id FROM Families WHERE [Name] = 'ACEROS - HIERROS - OTROS METALES'));

			INSERT INTO Categories([Name], [ModificationDate], [State], [FamilyId])
			VALUES('HIERROS REDONDOS TORSIONADOS', GETDATE(), 1, (SELECT Id FROM Families WHERE [Name] = 'ACEROS - HIERROS - OTROS METALES'));

			INSERT INTO Categories([Name], [ModificationDate], [State], [FamilyId])
			VALUES('MALLAS ELECTROSOLDADAS', GETDATE(), 1, (SELECT Id FROM Families WHERE [Name] = 'ACEROS - HIERROS - OTROS METALES'));

			INSERT INTO Categories([Name], [ModificationDate], [State], [FamilyId])
			VALUES('METAL DESPLEGADO', GETDATE(), 1, (SELECT Id FROM Families WHERE [Name] = 'ACEROS - HIERROS - OTROS METALES'));

			INSERT INTO Categories([Name], [ModificationDate], [State], [FamilyId])
			VALUES('PERFILES DE ACERO INOXIDABLE', GETDATE(), 1, (SELECT Id FROM Families WHERE [Name] = 'ACEROS - HIERROS - OTROS METALES'));

			INSERT INTO Categories([Name], [ModificationDate], [State], [FamilyId])
			VALUES('PERFILES DE ALUMINIO', GETDATE(), 1, (SELECT Id FROM Families WHERE [Name] = 'ACEROS - HIERROS - OTROS METALES'));

			INSERT INTO Categories([Name], [ModificationDate], [State], [FamilyId])
			VALUES('PERFILES DE BRONCE', GETDATE(), 1, (SELECT Id FROM Families WHERE [Name] = 'ACEROS - HIERROS - OTROS METALES'));

			INSERT INTO Categories([Name], [ModificationDate], [State], [FamilyId])
			VALUES('PERFILES DE HIERRO', GETDATE(), 1, (SELECT Id FROM Families WHERE [Name] = 'ACEROS - HIERROS - OTROS METALES'));

			INSERT INTO Categories([Name], [ModificationDate], [State], [FamilyId])
			VALUES('TORNILLOS', GETDATE(), 1, (SELECT Id FROM Families WHERE [Name] = 'ACEROS - HIERROS - OTROS METALES'));

			INSERT INTO Categories([Name], [ModificationDate], [State], [FamilyId])
			VALUES('TUBOS ESTRUCTURALES DE ACERO INOXIDABLE', GETDATE(), 1, (SELECT Id FROM Families WHERE [Name] = 'ACEROS - HIERROS - OTROS METALES'));

			INSERT INTO Categories([Name], [ModificationDate], [State], [FamilyId])
			VALUES('TUBOS ESTRUCTURALES DE ALUMINIO', GETDATE(), 1, (SELECT Id FROM Families WHERE [Name] = 'ACEROS - HIERROS - OTROS METALES'));

			INSERT INTO Categories([Name], [ModificationDate], [State], [FamilyId])
			VALUES('TUBOS ESTRUCTURALES DE HIERRO', GETDATE(), 1, (SELECT Id FROM Families WHERE [Name] = 'ACEROS - HIERROS - OTROS METALES'));
		END

		BEGIN /*INSERT CATEGORIES WHERE FAMILY NAME IS 'ADITIVOS - PEGAMENTOS - FIJACIONES'*/
			INSERT INTO Categories([Name], [ModificationDate], [State], [FamilyId])
			VALUES('ADITIVOS', GETDATE(), 1, (SELECT Id FROM Families WHERE [Name] = 'ADITIVOS - PEGAMENTOS - FIJACIONES'));

			INSERT INTO Categories([Name], [ModificationDate], [State], [FamilyId])
			VALUES('ANCLAJES', GETDATE(), 1, (SELECT Id FROM Families WHERE [Name] = 'ADITIVOS - PEGAMENTOS - FIJACIONES'));

			INSERT INTO Categories([Name], [ModificationDate], [State], [FamilyId])
			VALUES('BULONES Y TUERCAS', GETDATE(), 1, (SELECT Id FROM Families WHERE [Name] = 'ADITIVOS - PEGAMENTOS - FIJACIONES'));

			INSERT INTO Categories([Name], [ModificationDate], [State], [FamilyId])
			VALUES('FIJACIONES', GETDATE(), 1, (SELECT Id FROM Families WHERE [Name] = 'ADITIVOS - PEGAMENTOS - FIJACIONES'));

			INSERT INTO Categories([Name], [ModificationDate], [State], [FamilyId])
			VALUES('HIDROFUGOS', GETDATE(), 1, (SELECT Id FROM Families WHERE [Name] = 'ADITIVOS - PEGAMENTOS - FIJACIONES'));

			INSERT INTO Categories([Name], [ModificationDate], [State], [FamilyId])
			VALUES('MASILLAS', GETDATE(), 1, (SELECT Id FROM Families WHERE [Name] = 'ADITIVOS - PEGAMENTOS - FIJACIONES'));

			INSERT INTO Categories([Name], [ModificationDate], [State], [FamilyId])
			VALUES('PEGAMENTOS', GETDATE(), 1, (SELECT Id FROM Families WHERE [Name] = 'ADITIVOS - PEGAMENTOS - FIJACIONES'));
		END

		BEGIN /*INSERT CATEGORIES WHERE FAMILY NAME IS 'AGLOMERANTES - PREMEZCLADOS'*/
			INSERT INTO Categories([Name], [ModificationDate], [State], [FamilyId])
			VALUES('CALES', GETDATE(), 1, (SELECT Id FROM Families WHERE [Name] = 'AGLOMERANTES - PREMEZCLADOS'));

			INSERT INTO Categories([Name], [ModificationDate], [State], [FamilyId])
			VALUES('CEMENTOS', GETDATE(), 1, (SELECT Id FROM Families WHERE [Name] = 'AGLOMERANTES - PREMEZCLADOS'));

			INSERT INTO Categories([Name], [ModificationDate], [State], [FamilyId])
			VALUES('PREMEZCLADOS', GETDATE(), 1, (SELECT Id FROM Families WHERE [Name] = 'AGLOMERANTES - PREMEZCLADOS'));

			INSERT INTO Categories([Name], [ModificationDate], [State], [FamilyId])
			VALUES('YESOS', GETDATE(), 1, (SELECT Id FROM Families WHERE [Name] = 'AGLOMERANTES - PREMEZCLADOS'));
		END

		BEGIN /*INSERT CATEGORIES WHERE FAMILY NAME IS 'AISLANTES'*/
			INSERT INTO Categories([Name], [ModificationDate], [State], [FamilyId])
			VALUES('AISLANTES ACUSTICOS', GETDATE(), 1, (SELECT Id FROM Families WHERE [Name] = 'AISLANTES'));

			INSERT INTO Categories([Name], [ModificationDate], [State], [FamilyId])
			VALUES('AISLANTES HIDROFUGOS', GETDATE(), 1, (SELECT Id FROM Families WHERE [Name] = 'AISLANTES'));

			INSERT INTO Categories([Name], [ModificationDate], [State], [FamilyId])
			VALUES('AISLANTES TERMICOS', GETDATE(), 1, (SELECT Id FROM Families WHERE [Name] = 'AISLANTES'));

			INSERT INTO Categories([Name], [ModificationDate], [State], [FamilyId])
			VALUES('TIPO NUEVO', GETDATE(), 1, (SELECT Id FROM Families WHERE [Name] = 'AISLANTES'));
		END

		BEGIN /*INSERT CATEGORIES WHERE FAMILY NAME IS 'ARIDOS'*/
			INSERT INTO Categories([Name], [ModificationDate], [State], [FamilyId])
			VALUES('AGREGADOS GRUESOS', GETDATE(), 1, (SELECT Id FROM Families WHERE [Name] = 'ARIDOS'));

			INSERT INTO Categories([Name], [ModificationDate], [State], [FamilyId])
			VALUES('AGREGADOS LIVIANOS', GETDATE(), 1, (SELECT Id FROM Families WHERE [Name] = 'ARIDOS'));

			INSERT INTO Categories([Name], [ModificationDate], [State], [FamilyId])
			VALUES('ARENAS', GETDATE(), 1, (SELECT Id FROM Families WHERE [Name] = 'ARIDOS'));

			INSERT INTO Categories([Name], [ModificationDate], [State], [FamilyId])
			VALUES('TIERRAS Y ARCILLAS', GETDATE(), 1, (SELECT Id FROM Families WHERE [Name] = 'ARIDOS'));
		END
	END

	--INSERT PROVIDERS
	IF NOT EXISTS (SELECT * FROM Providers)
		BEGIN
			PRINT 'INSERT PROVIDERS'
			INSERT INTO Providers([Name],[ModificationDate],[State], [CUIT], [Address])
			VALUES('Proveedor 1', GETDATE(), 1, 123456, 'Calle falsa 1243');

			INSERT INTO Providers([Name],[ModificationDate],[State], [CUIT], [Address])
			VALUES('Proveedor 2', GETDATE(), 1, 456123, 'Calle falsa 1234');
		END
END