BEGIN TRANSACTION;
INSERT INTO "VideoSequences" ("Id") VALUES 
 (1), -- music intro
 (2), -- enter shrink - rock
 (3), -- enter shrink - pop
 (4), -- enter shrink - hiphop
 (5), -- enter shrink - jazz
 (6), -- enter shrink - classical
 (7), -- enter shrink - edm
 (8), -- football intro
 (9), -- football outro - friends
 (10), -- football outro - sneak
 (11), -- football outro - gift
 (12), -- horror intro
 (13), -- horror outro - fight
 (14), -- horror outro - run
 (15), -- horror outro - converse
 (16), -- car intro
 (17), -- car let pass
 (18), -- car speed up
 (19); -- ending
INSERT INTO "Videos" ("Id","Order","Path","AmbiencePath","VideoSequenceId") VALUES 
 (1,0,'1-0.webm',NULL,1),
 (2,0,'1-1-rock.webm',NULL,2),
 (3,0,'1-3-pop.webm',NULL,3),
 (4,0,'1-2-hiphop.webm',NULL,4),
 (5,0,'1-4-jazz.webm',NULL,5),
 (6,0,'1-6-classical.webm',NULL,6),
 (7,0,'1-5-edm.webm',NULL,7),
 (8,0,'2-0.webm',NULL,8),
 (9,0,'2-1.webm',NULL,9),
 (10,0,'2-2.webm',NULL,10),
 (11,0,'2-3.webm',NULL,11),
 (12,0,'3-0.webm',NULL,12),
 (13,0,'3-1.webm',NULL,13),
 (14,0,'3-2.webm',NULL,14),
 (15,0,'3-3.webm',NULL,15),
 (16,0,'4-0.webm',NULL,16),
 (17,0,'4-1.webm',NULL,17),
 (18,0,'4-2.webm',NULL,18),
 (19,1,'5-0.webm',NULL,17),
 (20,1,'5-0.webm',NULL,18);
INSERT INTO "Questions" ("Id","Description","MotivePath","Ordering","IntroVideoId") VALUES 
 (1,NULL,NULL,1,1), -- Genre choice
 (2,NULL,NULL,2,NULL), -- 4 images
 (3,NULL,NULL,3,8), -- Football
 (4,NULL,NULL,4,12), -- Horror house fight / flight
 (5,NULL,NULL,5,16); -- Car scene
INSERT INTO "Answers" ("Id","Text","ImagePath","AnswerOrder","OutroVideoId","QuestionId","FollowUpQuestionId") VALUES 
 (1,'Rock',NULL,0,2,1,NULL),
 (2,'Pop',NULL,1,3,1,NULL),
 (3,'Hip-hop',NULL,2,4,1,NULL),
 (4,'Jazz',NULL,3,5,1,NULL),
 (5,'Classical',NULL,4,6,1,NULL),
 (6,'EDM',NULL,5,7,1,NULL),
 (7,NULL,'sci-fi.jpg',0,NULL,2,NULL),
 (8,NULL,'sport.jpg',1,NULL,2,NULL),
 (9,NULL,'rpg.jpg',2,NULL,2,NULL),
 (10,NULL,'puzzle.jpg',3,NULL,2,NULL),
 (11,'Write to friends',NULL,0,9,3,NULL),
 (12,'Sneak',NULL,1,10,3,NULL),
 (13,'Buy a gift',NULL,2,11,3,NULL),
 (14,'Fight',NULL,0,13,4,NULL),
 (15,'Run away',NULL,1,14,4,NULL),
 (16,'Converse',NULL,2,15,4,NULL),
 (17,'Let him pass',NULL,0,17,5,NULL),
 (18,'Speed up',NULL,1,18,5,NULL);
INSERT INTO "Tags" ("Id","TagName","Slug","RawGTagId") VALUES 
 (1,'Singleplayer','singleplayer',31),
 (2,'Multiplayer','multiplayer',7),
 (3,'Great Soundtrack','great-soundtrack',42),
 (4,'RPG','rpg',24),
 (5,'Story Rich','story-rich',118),
 (6,'Open World','open-world',36),
 (7,'Sci-fi','sci-fi',32),
 (8,'Horror','horror',16),
 (9,'Fantasy','fantasy',64),
 (10,'Difficult','difficult',49),
 (11,'Sandbox','sandbox',37),
 (12,'Survival','survival',1),
 (13,'Stealth','stealth',15),
 (14,'Free to play','free-to-play',79),
 (15,'Tactical','tactical',80),
 (16,'Turn-based','turn-based',102),
 (17,'RTS','rts',168),
 (18,'Mystery','mystery',117),
 (19,'Driving','driving',130),
 (20,'Management','management',67),
 (21,'Explore','explore',2326),
 (22,'Sport','sport',3815),
 (23,'War','war',70),
 (24,'Violent','violent',34),
 (25,'Competitive','competitive',170);
INSERT INTO "TagPoints" ("Id","TagId","AnswerId","Point") VALUES 
 (1,19,1,1),
 (2,10,1,1),
 (3,12,1,1),
 (4,23,1,1),
 (5,24,1,1),
 (6,10,2,-1),
 (7,21,2,-1),
 (8,18,2,-1),
 (9,4,2,1),
 (10,14,2,1),
 (11,5,3,1),
 (12,11,3,1),
 (13,20,4,1),
 (14,15,4,1),
 (15,17,4,1),
 (16,24,4,-1),
 (17,8,5,1),
 (18,7,5,1),
 (19,13,5,1),
 (20,16,5,1),
 (21,14,5,-1),
 (22,19,6,1),
 (23,24,6,1),
 (24,2,6,1),
 (25,7,7,1),
 (26,9,7,1),
 (27,8,7,1),
 (28,5,7,1),
 (29,19,7,-1),
 (30,22,8,1),
 (31,11,8,1),
 (32,2,8,1),
 (33,24,8,1),
 (34,25,8,1),
 (35,4,9,1),
 (36,2,9,1),
 (37,1,9,1),
 (38,9,9,1),
 (39,23,9,1),
 (40,21,9,1),
 (41,20,10,1),
 (42,17,10,1),
 (43,16,10,1),
 (44,15,10,1),
 (45,10,10,1),
 (46,24,10,-1),
 (47,4,10,-1),
 (48,2,11,1),
 (49,12,11,1),
 (50,15,11,1),
 (51,20,11,1),
 (52,13,12,1),
 (53,18,12,1),
 (54,10,12,1),
 (55,1,12,1),
 (56,2,12,-1),
 (57,1,13,1),
 (58,14,13,-1),
 (59,15,13,1),
 (60,2,13,-1),
 (61,23,13,-1),
 (62,8,14,-1),
 (63,12,14,1),
 (64,21,14,-1),
 (65,10,14,-1),
 (66,23,14,-1),
 (67,24,14,-1),
 (68,5,14,-1),
 (69,24,15,1),
 (70,23,15,1),
 (71,8,15,1),
 (72,9,15,1),
 (73,4,15,-1),
 (74,21,16,1),
 (75,4,16,1),
 (76,18,16,1),
 (77,22,16,-1),
 (78,23,16,-1),
 (79,25,17,-1),
 (80,19,17,-1),
 (81,12,17,1),
 (82,25,18,1),
 (83,19,18,1),
 (84,11,18,1);
COMMIT;
