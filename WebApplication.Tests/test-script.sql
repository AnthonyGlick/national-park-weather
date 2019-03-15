--DELETE tables
DELETE FROM weather;
DELETE FROM survey_result;
DELETE FROM users;
DELETE FROM park;
--BUILD stripped down DB for testing

--ADD a park
INSERT INTO park VALUES ('CVNP', 'Cuyahoga Valley National Park', 'Ohio', 32832, 696, 125, 0, 'Woodland', 2000, 2189849, 'Of all the paths you take in life, make sure a few of them are dirt.', 'John Muir', 'Though a short distance from the urban areas of Cleveland and Akron, Cuyahoga Valley National Park seems worlds away. The park is a refuge for native plants and wildlife, and provides routes of discovery for visitors. The winding Cuyahoga River gives way to deep forests, rolling hills, and open farmlands. Walk or ride the Towpath Trail to follow the historic route of the Ohio & Erie Canal', 0, 390)
--ADD 5-day forecast for the park
INSERT INTO weather VALUES ('CVNP',1,38,62,'rain');
INSERT INTO weather VALUES ('CVNP',2,38,56,'partly cloudy');
INSERT INTO weather VALUES ('CVNP',3,51,66,'partly cloudy');
INSERT INTO weather VALUES ('CVNP',4,55,65,'rain');
INSERT INTO weather VALUES ('CVNP',5,53,69,'thunderstorms');

--ADD survey_results for the park
INSERT INTO survey_result VALUES ('CVNP', 'tom@tom.com','Ohio','active');
