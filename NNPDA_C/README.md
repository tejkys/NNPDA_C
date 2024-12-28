CREATE USER medvidek IDENTIFIED BY sexyMedvidek;

GRANT ALL PRIVILEGES TO medvidek;

/////

	/*Create table cities*/


CREATE TABLE cities (
  id NUMBER PRIMARY KEY,
  name VARCHAR2(64),
  latitude NUMBER,
  longitude NUMBER);
	
	/*Populate with cities*/
	
BEGIN
INSERT INTO cities (id, name, latitude, longitude) VALUES (1, 'Praha', 50.0755381, 14.4378005);
INSERT INTO cities (id, name, latitude, longitude) VALUES (2, 'Brno', 49.1950602, 16.6068371);
INSERT INTO cities (id, name, latitude, longitude) VALUES (3, 'Ostrava', 49.820923, 18.2625249);
INSERT INTO cities (id, name, latitude, longitude) VALUES (4, 'Plzeň', 49.738431, 13.3736377);
INSERT INTO cities (id, name, latitude, longitude) VALUES (5, 'Liberec', 50.7671123, 15.0568959);
INSERT INTO cities (id, name, latitude, longitude) VALUES (6, 'Olomouc', 49.5937786, 17.2508784);
INSERT INTO cities (id, name, latitude, longitude) VALUES (7, 'České Budějovice', 48.9744686, 14.4744274);
INSERT INTO cities (id, name, latitude, longitude) VALUES (8, 'Hradec Králové', 50.2086953, 15.83294);
INSERT INTO cities (id, name, latitude, longitude) VALUES (9, 'Ústí nad Labem', 50.6606349, 14.0320148);
INSERT INTO cities (id, name, latitude, longitude) VALUES (10, 'Pardubice', 50.0341456, 15.7614235);
INSERT INTO cities (id, name, latitude, longitude) VALUES (11, 'Zlín', 49.2260439, 17.6681899);
INSERT INTO cities (id, name, latitude, longitude) VALUES (12, 'Havířov', 49.7772415, 18.4368767);
INSERT INTO cities (id, name, latitude, longitude) VALUES (13, 'Kladno', 50.1432394, 14.1025844);
INSERT INTO cities (id, name, latitude, longitude) VALUES (14, 'Most', 50.5035578, 13.6361139);
INSERT INTO cities (id, name, latitude, longitude) VALUES (15, 'Karviná', 49.8544613, 18.5416475);
INSERT INTO cities (id, name, latitude, longitude) VALUES (16, 'Opava', 49.9383889, 17.9027499);
INSERT INTO cities (id, name, latitude, longitude) VALUES (17, 'Frýdek-Místek', 49.6844217, 18.3511849);
INSERT INTO cities (id, name, latitude, longitude) VALUES (18, 'Jihlava', 49.3968787, 15.5919361);
INSERT INTO cities (id, name, latitude, longitude) VALUES (19, 'Teplice', 50.6407345, 13.8245915);
INSERT INTO cities (id, name, latitude, longitude) VALUES (20, 'Děčín', 50.7796424, 14.2148534);
INSERT INTO cities (id, name, latitude, longitude) VALUES (21, 'Karlovy Vary', 50.2329688, 12.871827);
INSERT INTO cities (id, name, latitude, longitude) VALUES (22, 'Chomutov', 50.4608261, 13.4170669);
INSERT INTO cities (id, name, latitude, longitude) VALUES (23, 'Jablonec nad Nisou', 50.7241328, 15.1700144);
INSERT INTO cities (id, name, latitude, longitude) VALUES (24, 'Mladá Boleslav', 50.4108409, 14.9022586);
INSERT INTO cities (id, name, latitude, longitude) VALUES (25, 'Prostějov', 49.4710671, 17.1137437);
INSERT INTO cities (id, name, latitude, longitude) VALUES (26, 'Třebíč', 49.2144236, 15.88191);
INSERT INTO cities (id, name, latitude, longitude) VALUES (27, 'Třinec', 49.6779945, 18.6707285);
INSERT INTO cities (id, name, latitude, longitude) VALUES (28, 'Tábor', 49.414867, 14.6590358);
INSERT INTO cities (id, name, latitude, longitude) VALUES (29, 'Znojmo', 48.8551275, 16.0487289);
INSERT INTO cities (id, name, latitude, longitude) VALUES (30, 'Přerov', 49.4553955, 17.4503157);
END;

ALTER TABLE cities ADD (location SDO_GEOMETRY);

UPDATE cities SET location = 
  SDO_GEOMETRY(
    2001,
    8307,
    SDO_POINT_TYPE(longitude, latitude, NULL),
    NULL,
    NULL
   );
	 
INSERT INTO user_sdo_geom_metadata VALUES (
  'cities',
  'location', 
  SDO_DIM_ARRAY(
    SDO_DIM_ELEMENT('Longitude',-180, 180, 0.5), 
    SDO_DIM_ELEMENT('Latitude',-90, 90, 0.5)
  ), 
  8307
);

CREATE INDEX cities_location_spatial_idx on cities(location) INDEXTYPE IS MDSYS.SPATIAL_INDEX;

CREATE TABLE roads (
    id NUMBER PRIMARY KEY,
    start_city_id NUMBER,
    end_city_id NUMBER,
    length NUMBER,
    shape SDO_GEOMETRY
);

BEGIN
insert into roads (id, start_city_id, end_city_id, length) values (1, 6, 17, 44.69);
insert into roads (id, start_city_id, end_city_id, length) values (2, 5, 8, 50.14);
insert into roads (id, start_city_id, end_city_id, length) values (3, 23, 10, 64.37);
insert into roads (id, start_city_id, end_city_id, length) values (4, 9, 24, 54.25);
insert into roads (id, start_city_id, end_city_id, length) values (5, 26, 16, 53.14);
insert into roads (id, start_city_id, end_city_id, length) values (6, 19, 16, 49.42);
insert into roads (id, start_city_id, end_city_id, length) values (7, 2, 6, 95.13);
insert into roads (id, start_city_id, end_city_id, length) values (8, 17, 25, 28.25);
insert into roads (id, start_city_id, end_city_id, length) values (9, 5, 21, 35.61);
insert into roads (id, start_city_id, end_city_id, length) values (10, 13, 13, 29.79);
insert into roads (id, start_city_id, end_city_id, length) values (11, 5, 10, 71.44);
insert into roads (id, start_city_id, end_city_id, length) values (12, 20, 24, 84.67);
insert into roads (id, start_city_id, end_city_id, length) values (13, 30, 1, 69.06);
insert into roads (id, start_city_id, end_city_id, length) values (14, 19, 11, 96.0);
insert into roads (id, start_city_id, end_city_id, length) values (15, 22, 13, 70.51);
insert into roads (id, start_city_id, end_city_id, length) values (16, 25, 5, 49.78);
insert into roads (id, start_city_id, end_city_id, length) values (17, 14, 27, 2.55);
insert into roads (id, start_city_id, end_city_id, length) values (18, 5, 5, 15.98);
insert into roads (id, start_city_id, end_city_id, length) values (19, 15, 26, 90.82);
insert into roads (id, start_city_id, end_city_id, length) values (20, 13, 22, 7.06);
insert into roads (id, start_city_id, end_city_id, length) values (21, 24, 5, 15.89);
insert into roads (id, start_city_id, end_city_id, length) values (22, 5, 16, 56.23);
insert into roads (id, start_city_id, end_city_id, length) values (23, 24, 15, 77.06);
insert into roads (id, start_city_id, end_city_id, length) values (24, 5, 1, 1.22);
insert into roads (id, start_city_id, end_city_id, length) values (25, 2, 11, 22.7);
insert into roads (id, start_city_id, end_city_id, length) values (26, 10, 4, 4.61);
insert into roads (id, start_city_id, end_city_id, length) values (27, 29, 13, 8.96);
insert into roads (id, start_city_id, end_city_id, length) values (28, 22, 19, 72.66);
insert into roads (id, start_city_id, end_city_id, length) values (29, 9, 24, 50.85);
insert into roads (id, start_city_id, end_city_id, length) values (30, 4, 5, 94.8);
insert into roads (id, start_city_id, end_city_id, length) values (31, 29, 28, 65.43);
insert into roads (id, start_city_id, end_city_id, length) values (32, 14, 23, 12.05);
insert into roads (id, start_city_id, end_city_id, length) values (33, 20, 8, 58.31);
insert into roads (id, start_city_id, end_city_id, length) values (34, 23, 21, 98.96);
insert into roads (id, start_city_id, end_city_id, length) values (35, 26, 5, 22.57);
insert into roads (id, start_city_id, end_city_id, length) values (36, 11, 13, 22.28);
insert into roads (id, start_city_id, end_city_id, length) values (37, 9, 15, 58.51);
insert into roads (id, start_city_id, end_city_id, length) values (38, 2, 6, 52.74);
insert into roads (id, start_city_id, end_city_id, length) values (39, 16, 9, 59.99);
insert into roads (id, start_city_id, end_city_id, length) values (40, 23, 7, 59.09);
insert into roads (id, start_city_id, end_city_id, length) values (41, 21, 27, 73.53);
insert into roads (id, start_city_id, end_city_id, length) values (42, 6, 10, 93.45);
insert into roads (id, start_city_id, end_city_id, length) values (43, 27, 26, 44.17);
insert into roads (id, start_city_id, end_city_id, length) values (44, 9, 11, 86.79);
insert into roads (id, start_city_id, end_city_id, length) values (45, 12, 14, 73.25);
insert into roads (id, start_city_id, end_city_id, length) values (46, 9, 27, 60.11);
insert into roads (id, start_city_id, end_city_id, length) values (47, 13, 28, 84.03);
insert into roads (id, start_city_id, end_city_id, length) values (48, 28, 3, 38.49);
insert into roads (id, start_city_id, end_city_id, length) values (49, 12, 22, 42.47);
insert into roads (id, start_city_id, end_city_id, length) values (50, 28, 21, 91.12);
insert into roads (id, start_city_id, end_city_id, length) values (51, 27, 25, 61.87);
insert into roads (id, start_city_id, end_city_id, length) values (52, 13, 6, 32.08);
insert into roads (id, start_city_id, end_city_id, length) values (53, 12, 23, 99.55);
insert into roads (id, start_city_id, end_city_id, length) values (54, 7, 30, 5.02);
insert into roads (id, start_city_id, end_city_id, length) values (55, 30, 14, 28.84);
insert into roads (id, start_city_id, end_city_id, length) values (56, 16, 10, 30.94);
insert into roads (id, start_city_id, end_city_id, length) values (57, 22, 24, 14.29);
insert into roads (id, start_city_id, end_city_id, length) values (58, 21, 18, 11.22);
insert into roads (id, start_city_id, end_city_id, length) values (59, 6, 3, 76.02);
insert into roads (id, start_city_id, end_city_id, length) values (60, 18, 5, 85.98);
END;

UPDATE roads r
SET
    r.shape = SDO_GEOMETRY(
        2002,
        8307,
        NULL,
        SDO_ELEM_INFO_ARRAY(1, 2, 1),
        SDO_ORDINATE_ARRAY(
            (SELECT c.longitude FROM cities c WHERE c.id = r.start_city_id),
            (SELECT c.latitude FROM cities c WHERE c.id = r.start_city_id),
            (SELECT c.longitude FROM cities c WHERE c.id = r.end_city_id),
            (SELECT c.latitude FROM cities c WHERE c.id = r.end_city_id)
        )
    );
		
		
SELECT id, name, SDO_NN_DISTANCE(1) AS distance
                FROM cities
                WHERE
                   SDO_NN(
                      location,
                      SDO_GEOMETRY(
                           2001,
                           8307,
                           SDO_POINT_TYPE((SELECT longitude FROM cities WHERE name='Liberec') ,(SELECT latitude FROM cities WHERE name='Liberec') , NULL),
                          NULL,
                           NULL
                       ),
                       'sdo_num_res=4 unit=KM',
                       1
                   ) = 'TRUE'
                ORDER BY distance;
								
								SELECT id, name, SDO_NN_DISTANCE(1) AS distance FROM cities WHERE SDO_NN(location, SDO_GEOMETRY( 2001,8307,SDO_POINT_TYPE((SELECT longitude FROM cities WHERE name='Liberec') ,(SELECT latitude FROM cities WHERE name='Liberec') , NULL),NULL, NULL ),'sdo_num_res=4 unit=KM',1) = 'TRUE' ORDER BY distance;