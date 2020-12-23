use BasketUnit

-- Nationalities

insert into Nationalities (Name, Flag) values ('USA', 0x)
insert into Nationalities (Name, Flag) values ('Brazylia', 0x)
insert into Nationalities (Name, Flag) values ('Argentyna', 0x)
insert into Nationalities (Name, Flag) values ('Kanada', 0x)
insert into Nationalities (Name, Flag) values ('Australia', 0x)
insert into Nationalities (Name, Flag) values ('Francja', 0x)
insert into Nationalities (Name, Flag) values ('Hiszpania', 0x)
insert into Nationalities (Name, Flag) values ('Chorwacja', 0x)
insert into Nationalities (Name, Flag) values ('Niemcy', 0x)
insert into Nationalities (Name, Flag) values ('Kamerun', 0x)


-- Workout types

insert into WorkoutTypes (Name, CreatedDate) values ('Si³ownia', getdate())
insert into WorkoutTypes (Name, CreatedDate) values ('Bieganie', getdate())
insert into WorkoutTypes (Name, CreatedDate) values ('Koz³owanie', getdate())
insert into WorkoutTypes (Name, CreatedDate) values ('Taktyka', getdate())
insert into WorkoutTypes (Name, CreatedDate) values ('Trening rzutowy', getdate())

-- Workouts

insert into Workouts (Name, WorkoutTypeId, CreatedDate) values ('Bench press', 1, getdate())
insert into Workouts (Name, WorkoutTypeId, CreatedDate) values ('Calf raises', 1, getdate())
insert into Workouts (Name, WorkoutTypeId, CreatedDate) values ('4 x 800m', 2, getdate())
insert into Workouts (Name, WorkoutTypeId, CreatedDate) values ('15xkoperta', 2, getdate())
insert into Workouts (Name, WorkoutTypeId, CreatedDate) values ('Full court between the legs', 3, getdate())
insert into Workouts (Name, WorkoutTypeId, CreatedDate) values ('Full court behind the back', 3, getdate())
insert into Workouts (Name, WorkoutTypeId, CreatedDate) values ('Triangle offense', 4, getdate())
insert into Workouts (Name, WorkoutTypeId, CreatedDate) values ('Deffensive transition', 4, getdate())
insert into Workouts (Name, WorkoutTypeId, CreatedDate) values ('5x20 mid range', 5, getdate())
insert into Workouts (Name, WorkoutTypeId, CreatedDate) values ('5x20 3-pointer', 5, getdate())


-- Arenas

insert into Arenas (Name, Capacity, Address, CreatedDate) values ('Inglewood Arena', 18000, 'Inglewood, California', getdate())
insert into Arenas (Name, Capacity, Address, CreatedDate) values ('Barclays Center', 18100, 'Brooklyn, NewYork, 620 Atlantic Avenue', getdate())
insert into Arenas (Name, Capacity, Address, CreatedDate) values ('Chase Center', 18000, 'San Francisco, California', getdate())
insert into Arenas (Name, Capacity, Address, CreatedDate) values ('Smoothie King Center', 18500, 'New Orleans, Louisiana, ', getdate())
insert into Arenas (Name, Capacity, Address, CreatedDate) values ('Toyota Center', 19000, 'Houston, Texas, 1510 Polk Street', getdate())
insert into Arenas (Name, Capacity, Address, CreatedDate) values ('Staples Center', 21000, 'Los Angeles, 1111 S. Figueroa Street', getdate())
insert into Arenas (Name, Capacity, Address, CreatedDate) values ('TD Garden', 18200, 'Boston, Massachusetts, 100 Legends Way', getdate())
insert into Arenas (Name, Capacity, Address, CreatedDate) values ('AmericanAirlines Arena', 19600, 'Miami, Florida, 601 Biscayne Boulevard', getdate())
insert into Arenas (Name, Capacity, Address, CreatedDate) values ('Wells Fargo Center', 18000, 'Philadelphia, Pennsylvania, 3601 South Broad Street', getdate())
insert into Arenas (Name, Capacity, Address, CreatedDate) values ('Madison Square Garden', 19800, 'New York, New York, 4 Pennsylvania Plaza', getdate())

-- Coaches

insert into People (FirstName, LastName, IsActive, BirthDate, NationalityId, Discriminator, ExperienceYears, CreatedDate) 
			values ('Tyronn', 'Lue', 1, '03-05-1977', 1, 'Coach', 10, getdate())
insert into People (FirstName, LastName, IsActive, BirthDate, NationalityId, Discriminator, ExperienceYears, CreatedDate) 
			values ('Steve', 'Nash', 1, '07-02-1974', 4, 'Coach', 10, getdate())
insert into People (FirstName, LastName, IsActive, BirthDate, NationalityId, Discriminator, ExperienceYears, CreatedDate) 
			values ('Steve', 'Kerr', 1, '09-27-1965', 1, 'Coach', 10, getdate())
insert into People (FirstName, LastName, IsActive, BirthDate, NationalityId, Discriminator, ExperienceYears, CreatedDate) 
			values ('Stan', 'Van Gundy', 1, '08-26-1959', 1, 'Coach', 10, getdate())
insert into People (FirstName, LastName, IsActive, BirthDate, NationalityId, Discriminator, ExperienceYears, CreatedDate) 
			values ('Stephen', 'Silas', 1, '01-21-1973', 1, 'Coach', 10, getdate())
insert into People (FirstName, LastName, IsActive, BirthDate, NationalityId, Discriminator, ExperienceYears, CreatedDate) 
			values ('Frank', 'Vogel', 1, '06-21-1973', 1, 'Coach', 10, getdate())
insert into People (FirstName, LastName, IsActive, BirthDate, NationalityId, Discriminator, ExperienceYears, CreatedDate) 
			values ('Brad', 'Stevens', 1, '10-22-1976', 1, 'Coach', 10, getdate())
insert into People (FirstName, LastName, IsActive, BirthDate, NationalityId, Discriminator, ExperienceYears, CreatedDate) 
			values ('Erik', 'Spoelstra', 1, '11-01-1970', 1, 'Coach', 10, getdate())
insert into People (FirstName, LastName, IsActive, BirthDate, NationalityId, Discriminator, ExperienceYears, CreatedDate) 
			values ('Brett', 'Brown', 1, '02-16-1961', 1, 'Coach', 10, getdate())
insert into People (FirstName, LastName, IsActive, BirthDate, NationalityId, Discriminator, ExperienceYears, CreatedDate) 
			values ('Tom', 'Thibodeau', 1, '01-17-1958', 1, 'Coach', 10, getdate())



-- Referees

insert into People (FirstName, LastName, IsActive, BirthDate, NationalityId, Discriminator, LicenseExpirationDate, CreatedDate)
			values ('Ray', 'Acosta', 1, '01-12-1967', 1, 'Referee', '03-20-2022', getdate())
insert into People (FirstName, LastName, IsActive, BirthDate, NationalityId, Discriminator, LicenseExpirationDate, CreatedDate)
			values ('Brandon', 'Adair', 1, '05-05-1977', 1, 'Referee', '07-25-2022', getdate())
insert into People (FirstName, LastName, IsActive, BirthDate, NationalityId, Discriminator, LicenseExpirationDate, CreatedDate)
			values ('Mark', 'Ayotte', 1, '10-03-1969', 1, 'Referee', '10-23-2024', getdate())
insert into People (FirstName, LastName, IsActive, BirthDate, NationalityId, Discriminator, LicenseExpirationDate, CreatedDate)
			values ('Curtis', 'Blair', 1, '07-04-1963', 1, 'Referee', '04-20-2024', getdate())



-- Teams

insert into Teams (Name, City, ArenaId, CoachId, CreatedDate, Badge) values ('Clippers', 'Los Angeles', 1, 1, getdate(), 0x)
insert into Teams (Name, City, ArenaId, CoachId, CreatedDate, Badge) values ('Nets', 'Brooklyn', 2, 2, getdate(), 0x)
insert into Teams (Name, City, ArenaId, CoachId, CreatedDate, Badge) values ('Warriors', 'Golden State', 3, 3, getdate(), 0x)
insert into Teams (Name, City, ArenaId, CoachId, CreatedDate, Badge) values ('Pelicans', 'New Orleans', 4, 4, getdate(), 0x)
insert into Teams (Name, City, ArenaId, CoachId, CreatedDate, Badge) values ('Rockets', 'Houston', 5, 5, getdate(), 0x)
insert into Teams (Name, City, ArenaId, CoachId, CreatedDate, Badge) values ('Lakers', 'Los Angeles', 6, 6, getdate(), 0x)
insert into Teams (Name, City, ArenaId, CoachId, CreatedDate, Badge) values ('Celtics', 'Boston', 7, 7, getdate(), 0x)
insert into Teams (Name, City, ArenaId, CoachId, CreatedDate, Badge) values ('Heat', 'Miami', 8, 8, getdate(), 0x)
insert into Teams (Name, City, ArenaId, CoachId, CreatedDate, Badge) values ('76ers', 'Philadelphia', 9, 9, getdate(), 0x)
insert into Teams (Name, City, ArenaId, CoachId, CreatedDate, Badge) values ('Knicks', 'New York', 10, 10, getdate(), 0x)


-- Team schedules

insert into TeamSchedules (TeamId, CreatedDate) values (1, getdate())
insert into TeamSchedules (TeamId, CreatedDate) values (2, getdate())
insert into TeamSchedules (TeamId, CreatedDate) values (3, getdate())
insert into TeamSchedules (TeamId, CreatedDate) values (4, getdate())
insert into TeamSchedules (TeamId, CreatedDate) values (5, getdate())
insert into TeamSchedules (TeamId, CreatedDate) values (6, getdate())
insert into TeamSchedules (TeamId, CreatedDate) values (7, getdate())
insert into TeamSchedules (TeamId, CreatedDate) values (8, getdate())
insert into TeamSchedules (TeamId, CreatedDate) values (9, getdate())
insert into TeamSchedules (TeamId, CreatedDate) values (10, getdate())


-- Colleges

-- Id 1
insert into Colleges (City, Name, CreatedDate, Badge) values ('San Diego', 'Aztecs', getdate(), 0x)
-- Id 2
insert into Colleges (City, Name, CreatedDate, Badge) values ('Fresno State', 'Bulldogs', getdate(), 0x)
-- Id 3
insert into Colleges (City, Name, CreatedDate, Badge) values ('Arkansas', 'Razorbacks', getdate(), 0x)
-- Id 4
insert into Colleges (City, Name, CreatedDate, Badge) values ('', 'Republic of Congo', getdate(), 0x)
-- Id 5
insert into Colleges (City, Name, CreatedDate, Badge) values ('Boston', 'Eagles', getdate(), 0x)
-- Id 6
insert into Colleges (City, Name, CreatedDate, Badge) values ('Belgrade', 'Mega Soccerbet', getdate(), 0x)
-- Id 7
insert into Colleges (City, Name, CreatedDate, Badge) values ('Kansas', 'Jayhawks', getdate(), 0x)
-- Id 8
insert into Colleges (City, Name, CreatedDate, Badge) values ('Texas', 'Longhorns', getdate(), 0x)
-- Id 9
insert into Colleges (City, Name, CreatedDate, Badge) values ('Colorado', 'Buffaloes', getdate(), 0x)
-- Id 10
insert into Colleges (City, Name, CreatedDate, Badge) values ('Duke', 'Blue Devils', getdate(), 0x)
-- Id 11
insert into Colleges (City, Name, CreatedDate, Badge) values ('Georgetown', 'Hoyas', getdate(), 0x)
-- Id 12
insert into Colleges (City, Name, CreatedDate, Badge) values ('Texas', 'A&M Aggies', getdate(), 0x)
-- Id 13
insert into Colleges (City, Name, CreatedDate, Badge) values ('Virginia', 'Cavaliers', getdate(), 0x)
-- Id 14
insert into Colleges (City, Name, CreatedDate, Badge) values ('St. Vincent', 'St. Mary High School', getdate(), 0x)
-- Id 15
insert into Colleges (City, Name, CreatedDate, Badge) values ('Kentucky', 'Wildcats', getdate(), 0x)
-- Id 16
insert into Colleges (City, Name, CreatedDate, Badge) values ('Utah', 'Utes', getdate(), 0x)
-- Id 17
insert into Colleges (City, Name, CreatedDate, Badge) values ('Braunschweig', 'SG', getdate(), 0x)
-- Id 18
insert into Colleges (City, Name, CreatedDate, Badge) values ('Newark', 'St. Benedicts', getdate(), 0x)
-- Id 19
insert into Colleges (City, Name, CreatedDate, Badge) values ('Girona', 'CB', getdate(), 0x)
-- Id 20
insert into Colleges (City, Name, CreatedDate, Badge) values ('Louisville', 'Cardinals', getdate(), 0x)
-- Id 21
insert into Colleges (City, Name, CreatedDate, Badge) values ('LSU', 'Tigers', getdate(), 0x)
-- Id 22
insert into Colleges (City, Name, CreatedDate, Badge) values ('North Carolina', 'Tar Heels', getdate(), 0x)
-- Id 23
insert into Colleges (City, Name, CreatedDate, Badge) values ('Tennessee', 'Volunteers', getdate(), 0x)
-- Id 24
insert into Colleges (City, Name, CreatedDate, Badge) values ('Southwest Atlanta', 'Christian Academy', getdate(), 0x)
-- Id 25
insert into Colleges (City, Name, CreatedDate, Badge) values ('Norfolk State', 'Spartans', getdate(), 0x)



-- Clippers

-- Id 15
insert into People (FirstName, LastName, IsActive, BirthDate, NationalityId, Discriminator, Position, Number, Height, Weight, CollegeId, CreatedDate, Avatar)
			values ('Kawhi', 'Leonard', 1, '06-29-1991', 1, 'Player', 2, 2, 201, 102, 1, getdate(), 0x)
-- Id 16
insert into People (FirstName, LastName, IsActive, BirthDate, NationalityId, Discriminator, Position, Number, Height, Weight, CollegeId, CreatedDate, Avatar)
			values ('Paul', 'George', 1, '02-05-1990', 1, 'Player', 1, 13, 203, 99, 2, getdate(), 0x)
-- Id 17
insert into People (FirstName, LastName, IsActive, BirthDate, NationalityId, Discriminator, Position, Number, Height, Weight, CollegeId, CreatedDate, Avatar)
			values ('Patrick', 'Beverley', 1, '12-07-1988', 1, 'Player', 0, 21, 185, 81, 3, getdate(), 0x)
-- Id 18
insert into People (FirstName, LastName, IsActive, BirthDate, NationalityId, Discriminator, Position, Number, Height, Weight, CollegeId, CreatedDate, Avatar)
			values ('Serge', 'Ibaka', 1, '09-18-1989', 7, 'Player', 4, 9, 208, 108, 4, getdate(), 0x)
-- Id 19
insert into People (FirstName, LastName, IsActive, BirthDate, NationalityId, Discriminator, Position, Number, Height, Weight, CollegeId, CreatedDate, Avatar)
			values ('Reggie', 'Jackson', 1, '04-16-1990', 1, 'Player', 0, 1, 192, 94, 5, getdate(), 0x)
-- Id 20
insert into People (FirstName, LastName, IsActive, BirthDate, NationalityId, Discriminator, Position, Number, Height, Weight, CollegeId, CreatedDate, Avatar)
			values ('Lou', 'Williams', 1, '10-27-1986', 1, 'Player', 1, 23, 186, 79, 1, getdate(), 0x)
-- Id 21
insert into People (FirstName, LastName, IsActive, BirthDate, NationalityId, Discriminator, Position, Number, Height, Weight, CollegeId, CreatedDate, Avatar)
			values ('Ivica', 'Zubac', 1, '03-18-1997', 8, 'Player', 4, 23, 213, 120, 6, getdate(), 0x)
-- Id 22
insert into People (FirstName, LastName, IsActive, BirthDate, NationalityId, Discriminator, Position, Number, Height, Weight, CollegeId, CreatedDate, Avatar)
			values ('Marcus', 'Morris', 1, '02-09-1989', 1, 'Player', 3, 31, 206, 107, 7, getdate(), 0x)



insert into TeamLineups (TeamId, PlayerId, CreatedDate) values (1, 15, getdate())
insert into TeamLineups (TeamId, PlayerId, CreatedDate) values (1, 16, getdate())
insert into TeamLineups (TeamId, PlayerId, CreatedDate) values (1, 17, getdate())
insert into TeamLineups (TeamId, PlayerId, CreatedDate) values (1, 18, getdate())
insert into TeamLineups (TeamId, PlayerId, CreatedDate) values (1, 19, getdate())
insert into TeamLineups (TeamId, PlayerId, CreatedDate) values (1, 20, getdate())
insert into TeamLineups (TeamId, PlayerId, CreatedDate) values (1, 21, getdate())
insert into TeamLineups (TeamId, PlayerId, CreatedDate) values (1, 22, getdate())


insert into TeamFirstLineups (TeamId, PlayerId, CreatedDate) values (1, 17, getdate())
insert into TeamFirstLineups (TeamId, PlayerId, CreatedDate) values (1, 16, getdate())
insert into TeamFirstLineups (TeamId, PlayerId, CreatedDate) values (1, 15, getdate())
insert into TeamFirstLineups (TeamId, PlayerId, CreatedDate) values (1, 22, getdate())
insert into TeamFirstLineups (TeamId, PlayerId, CreatedDate) values (1, 21, getdate())




-- Nets

-- Id 23
insert into People (FirstName, LastName, IsActive, BirthDate, NationalityId, Discriminator, Position, Number, Height, Weight, CollegeId, CreatedDate, Avatar)
			values ('Jarret', 'Allen', 1, '04-21-1998', 1, 'Player', 4, 31, 211, 110, 8, getdate(), 0x)
-- Id 24
insert into People (FirstName, LastName, IsActive, BirthDate, NationalityId, Discriminator, Position, Number, Height, Weight, CollegeId, CreatedDate, Avatar)
			values ('Spencer', 'Dinwiddie', 1, '06-04-1993', 1, 'Player', 1, 26, 195, 98, 9, getdate(), 0x)
-- Id 25
insert into People (FirstName, LastName, IsActive, BirthDate, NationalityId, Discriminator, Position, Number, Height, Weight, CollegeId, CreatedDate, Avatar)
			values ('Kevin', 'Durant', 1, '09-29-1988', 1, 'Player', 2, 7, 208, 108, 8, getdate(), 0x)
-- Id 26
insert into People (FirstName, LastName, IsActive, BirthDate, NationalityId, Discriminator, Position, Number, Height, Weight, CollegeId, CreatedDate, Avatar)
			values ('Kyrie', 'Irving', 1, '03-23-1992', 5, 'Player', 0, 11, 188, 88, 10, getdate(), 0x)
-- Id 27
insert into People (FirstName, LastName, IsActive, BirthDate, NationalityId, Discriminator, Position, Number, Height, Weight, CollegeId, CreatedDate, Avatar)
			values ('Jeff', 'Green', 1, '08-28-1986', 1, 'Player', 3, 8, 203, 106, 11, getdate(), 0x)
-- Id 28
insert into People (FirstName, LastName, IsActive, BirthDate, NationalityId, Discriminator, Position, Number, Height, Weight, CollegeId, CreatedDate, Avatar)
			values ('DeAndre', 'Jordan', 1, '07-21-1988', 1, 'Player', 4, 6, 210, 120, 12, getdate(), 0x)
-- Id 29
insert into People (FirstName, LastName, IsActive, BirthDate, NationalityId, Discriminator, Position, Number, Height, Weight, CollegeId, CreatedDate, Avatar)
			values ('Joe', 'Harris', 1, '06-09-1991', 1, 'Player', 2, 12, 198, 100, 13, getdate(), 0x)
-- Id 30
insert into People (FirstName, LastName, IsActive, BirthDate, NationalityId, Discriminator, Position, Number, Height, Weight, CollegeId, CreatedDate, Avatar)
			values ('Tyler', 'Johnson', 1, '07-05-1992', 1, 'Player', 1, 10, 190, 84, 2, getdate(), 0x)


insert into TeamLineups (TeamId, PlayerId, CreatedDate) values (2, 23, getdate())
insert into TeamLineups (TeamId, PlayerId, CreatedDate) values (2, 24, getdate())
insert into TeamLineups (TeamId, PlayerId, CreatedDate) values (2, 25, getdate())
insert into TeamLineups (TeamId, PlayerId, CreatedDate) values (2, 26, getdate())
insert into TeamLineups (TeamId, PlayerId, CreatedDate) values (2, 27, getdate())
insert into TeamLineups (TeamId, PlayerId, CreatedDate) values (2, 28, getdate())
insert into TeamLineups (TeamId, PlayerId, CreatedDate) values (2, 29, getdate())
insert into TeamLineups (TeamId, PlayerId, CreatedDate) values (2, 30, getdate())

insert into TeamFirstLineups (TeamId, PlayerId, CreatedDate) values (2, 26, getdate())
insert into TeamFirstLineups (TeamId, PlayerId, CreatedDate) values (2, 30, getdate())
insert into TeamFirstLineups (TeamId, PlayerId, CreatedDate) values (2, 25, getdate())
insert into TeamFirstLineups (TeamId, PlayerId, CreatedDate) values (2, 27, getdate())
insert into TeamFirstLineups (TeamId, PlayerId, CreatedDate) values (2, 28, getdate())


-- Lakers

-- Id 31
insert into People (FirstName, LastName, IsActive, BirthDate, NationalityId, Discriminator, Position, Number, Height, Weight, CollegeId, CreatedDate, Avatar)
			values ('LeBron', 'James', 1, '12-30-1984', 1, 'Player', 2, 23, 203, 113, 14, getdate(), 0x)
-- Id 32
insert into People (FirstName, LastName, IsActive, BirthDate, NationalityId, Discriminator, Position, Number, Height, Weight, CollegeId, CreatedDate, Avatar)
			values ('Anthony', 'Davis', 1, '11-03-1993', 1, 'Player', 4, 3, 209, 115, 15, getdate(), 0x)
-- Id 33
insert into People (FirstName, LastName, IsActive, BirthDate, NationalityId, Discriminator, Position, Number, Height, Weight, CollegeId, CreatedDate, Avatar)
			values ('Kyle', 'Kuzma', 1, '07-24-1995', 1, 'Player', 2, 0, 203, 100, 16, getdate(), 0x)
-- Id 34
insert into People (FirstName, LastName, IsActive, BirthDate, NationalityId, Discriminator, Position, Number, Height, Weight, CollegeId, CreatedDate, Avatar)
			values ('Dennis', 'Schroeder', 1, '09-15-1993', 9, 'Player', 0, 17, 185, 78, 17, getdate(), 0x)
-- Id 35
insert into People (FirstName, LastName, IsActive, BirthDate, NationalityId, Discriminator, Position, Number, Height, Weight, CollegeId, CreatedDate, Avatar)
			values ('JR', 'Smith', 1, '09-09-1985', 1, 'Player', 1, 21, 198, 102, 18, getdate(), 0x)
-- Id 36
insert into People (FirstName, LastName, IsActive, BirthDate, NationalityId, Discriminator, Position, Number, Height, Weight, CollegeId, CreatedDate, Avatar)
			values ('Marc', 'Gasol', 1, '01-29-1985', 7, 'Player', 3, 33, 210, 115, 19, getdate(), 0x)
-- Id 37
insert into People (FirstName, LastName, IsActive, BirthDate, NationalityId, Discriminator, Position, Number, Height, Weight, CollegeId, CreatedDate, Avatar)
			values ('Montrezl', 'Harrell', 1, '01-26-1994', 1, 'Player', 3, 5, 201, 108, 20, getdate(), 0x)
-- Id 38
insert into People (FirstName, LastName, IsActive, BirthDate, NationalityId, Discriminator, Position, Number, Height, Weight, CollegeId, CreatedDate, Avatar)
			values ('Alex', 'Caruso', 1, '02-28-1994', 1, 'Player', 1, 4, 195, 84, 12, getdate(), 0x)


insert into TeamLineups (TeamId, PlayerId, CreatedDate) values (6, 31, getdate())
insert into TeamLineups (TeamId, PlayerId, CreatedDate) values (6, 32, getdate())
insert into TeamLineups (TeamId, PlayerId, CreatedDate) values (6, 33, getdate())
insert into TeamLineups (TeamId, PlayerId, CreatedDate) values (6, 34, getdate())
insert into TeamLineups (TeamId, PlayerId, CreatedDate) values (6, 35, getdate())
insert into TeamLineups (TeamId, PlayerId, CreatedDate) values (6, 36, getdate())
insert into TeamLineups (TeamId, PlayerId, CreatedDate) values (6, 37, getdate())
insert into TeamLineups (TeamId, PlayerId, CreatedDate) values (6, 38, getdate())

insert into TeamFirstLineups (TeamId, PlayerId, CreatedDate) values (6, 34, getdate())
insert into TeamFirstLineups (TeamId, PlayerId, CreatedDate) values (6, 33, getdate())
insert into TeamFirstLineups (TeamId, PlayerId, CreatedDate) values (6, 31, getdate())
insert into TeamFirstLineups (TeamId, PlayerId, CreatedDate) values (6, 36, getdate())
insert into TeamFirstLineups (TeamId, PlayerId, CreatedDate) values (6, 32, getdate())


-- 76ers

-- Id 39
insert into People (FirstName, LastName, IsActive, BirthDate, NationalityId, Discriminator, Position, Number, Height, Weight, CollegeId, CreatedDate, Avatar)
			values ('Joel', 'Embiid', 1, '03-16-1994', 10, 'Player', 4, 21, 213, 127, 7, getdate(), 0x)
-- Id 40
insert into People (FirstName, LastName, IsActive, BirthDate, NationalityId, Discriminator, Position, Number, Height, Weight, CollegeId, CreatedDate, Avatar)
			values ('Ben', 'Simmons', 1, '03-16-1994', 5, 'Player', 0, 25, 208, 108, 21, getdate(), 0x)
-- Id 41
insert into People (FirstName, LastName, IsActive, BirthDate, NationalityId, Discriminator, Position, Number, Height, Weight, CollegeId, CreatedDate, Avatar)
			values ('Danny', 'Green', 1, '06-22-1987', 1, 'Player', 1, 14, 198, 97, 22, getdate(), 0x)
-- Id 42
insert into People (FirstName, LastName, IsActive, BirthDate, NationalityId, Discriminator, Position, Number, Height, Weight, CollegeId, CreatedDate, Avatar)
			values ('Tobias', 'Harris', 1, '07-15-1992', 1, 'Player', 2, 12, 203, 102, 23, getdate(), 0x)
-- Id 43
insert into People (FirstName, LastName, IsActive, BirthDate, NationalityId, Discriminator, Position, Number, Height, Weight, CollegeId, CreatedDate, Avatar)
			values ('Dwight', 'Howard', 1, '08-12-1985', 1, 'Player', 3, 39, 208, 120, 24, getdate(), 0x)
-- Id 44
insert into People (FirstName, LastName, IsActive, BirthDate, NationalityId, Discriminator, Position, Number, Height, Weight, CollegeId, CreatedDate, Avatar)
			values ('Seth', 'Curry', 1, '08-23-1990', 1, 'Player', 1, 31, 187, 83, 10, getdate(), 0x)
-- Id 45
insert into People (FirstName, LastName, IsActive, BirthDate, NationalityId, Discriminator, Position, Number, Height, Weight, CollegeId, CreatedDate, Avatar)
			values ('Kyle', 'OQuinn', 1, '03-26-1990', 1, 'Player', 3, 9, 205, 113, 25, getdate(), 0x)
-- Id 46
insert into People (FirstName, LastName, IsActive, BirthDate, NationalityId, Discriminator, Position, Number, Height, Weight, CollegeId, CreatedDate, Avatar)
			values ('Tyrese', 'Maxey', 1, '04-11-2000', 1, 'Player', 0, 0, 190, 90, 15, getdate(), 0x)


insert into TeamLineups (TeamId, PlayerId, CreatedDate) values (9, 39, getdate())
insert into TeamLineups (TeamId, PlayerId, CreatedDate) values (9, 40, getdate())
insert into TeamLineups (TeamId, PlayerId, CreatedDate) values (9, 41, getdate())
insert into TeamLineups (TeamId, PlayerId, CreatedDate) values (9, 42, getdate())
insert into TeamLineups (TeamId, PlayerId, CreatedDate) values (9, 43, getdate())
insert into TeamLineups (TeamId, PlayerId, CreatedDate) values (9, 44, getdate())
insert into TeamLineups (TeamId, PlayerId, CreatedDate) values (9, 45, getdate())
insert into TeamLineups (TeamId, PlayerId, CreatedDate) values (9, 46, getdate())

insert into TeamFirstLineups (TeamId, PlayerId, CreatedDate) values (9, 40, getdate())
insert into TeamFirstLineups (TeamId, PlayerId, CreatedDate) values (9, 41, getdate())
insert into TeamFirstLineups (TeamId, PlayerId, CreatedDate) values (9, 42, getdate())
insert into TeamFirstLineups (TeamId, PlayerId, CreatedDate) values (9, 43, getdate())
insert into TeamFirstLineups (TeamId, PlayerId, CreatedDate) values (9, 39, getdate())




-- Games
-- Id 1
insert into Games (Date, ArenaId, CreatedDate) values ('12-25-2020', 1, getdate())
-- Id 2
insert into Games (Date, ArenaId, CreatedDate) values ('12-27-2020', 6, getdate())
-- Id 3
insert into Games (Date, ArenaId, CreatedDate) values ('12-29-2020', 9, getdate())
-- Id 4
insert into Games (Date, ArenaId, CreatedDate) values ('01-03-2021', 2, getdate())
-- Id 5
insert into Games (Date, ArenaId, CreatedDate) values ('01-05-2021', 6, getdate())
-- Id 6
insert into Games (Date, ArenaId, CreatedDate) values ('01-07-2021', 6, getdate())


-- GameReferees
insert into GameReferees (GameId, RefereeId, CreatedDate) values (1, 11, getdate())
insert into GameReferees (GameId, RefereeId, CreatedDate) values (1, 12, getdate())
insert into GameReferees (GameId, RefereeId, CreatedDate) values (2, 13, getdate())
insert into GameReferees (GameId, RefereeId, CreatedDate) values (2, 14, getdate())
insert into GameReferees (GameId, RefereeId, CreatedDate) values (3, 11, getdate())
insert into GameReferees (GameId, RefereeId, CreatedDate) values (3, 14, getdate())
insert into GameReferees (GameId, RefereeId, CreatedDate) values (4, 12, getdate())
insert into GameReferees (GameId, RefereeId, CreatedDate) values (4, 13, getdate())
insert into GameReferees (GameId, RefereeId, CreatedDate) values (5, 12, getdate())
insert into GameReferees (GameId, RefereeId, CreatedDate) values (5, 14, getdate())
insert into GameReferees (GameId, RefereeId, CreatedDate) values (6, 11, getdate())
insert into GameReferees (GameId, RefereeId, CreatedDate) values (6, 13, getdate())


-- GameTeams
insert into GameTeams (GameId, TeamId, CreatedDate) values (1, 1, getdate())
insert into GameTeams (GameId, TeamId, CreatedDate) values (1, 2, getdate())
insert into GameTeams (GameId, TeamId, CreatedDate) values (2, 6, getdate())
insert into GameTeams (GameId, TeamId, CreatedDate) values (2, 1, getdate())
insert into GameTeams (GameId, TeamId, CreatedDate) values (3, 9, getdate())
insert into GameTeams (GameId, TeamId, CreatedDate) values (3, 1, getdate())
insert into GameTeams (GameId, TeamId, CreatedDate) values (4, 2, getdate())
insert into GameTeams (GameId, TeamId, CreatedDate) values (4, 6, getdate())
insert into GameTeams (GameId, TeamId, CreatedDate) values (5, 6, getdate())
insert into GameTeams (GameId, TeamId, CreatedDate) values (5, 9, getdate())
insert into GameTeams (GameId, TeamId, CreatedDate) values (6, 9, getdate())
insert into GameTeams (GameId, TeamId, CreatedDate) values (6, 2, getdate())

-- Stats

-- Clippers vs Nets
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (1, 15, 39, 6, 2, 0, 4, 3, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (1, 22, 15, 2, 4, 0, 1, 2, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (1, 21, 8, 2, 15, 1, 0, 2, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (1, 19, 5, 3, 1, 0, 0, 2, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (1, 20, 18, 3, 3, 2, 1, 2, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (1, 16, 14, 3, 0, 0, 0, 3, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (1, 17, 8, 3, 1, 1, 0, 3, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (1, 18, 8, 2, 2, 0, 0, 3, getdate())

insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (1, 23, 7, 1, 8, 0, 2, 4, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (1, 24, 5, 2, 1, 1, 1, 2, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (1, 25, 27, 1, 12, 1, 1, 4, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (1, 26, 22, 10, 4, 0, 1, 3, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (1, 27, 0, 0, 0, 0, 0, 0, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (1, 28, 6, 3, 7, 0, 0, 3, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (1, 29, 15, 2, 9, 3, 0, 1, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (1, 30, 16, 3, 7, 2, 0, 4, getdate())


-- Lakers vs Clippers

insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (2, 31, 28, 9, 8, 0, 2, 3, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (2, 32, 30, 2, 7, 2, 1, 5, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (2, 33, 8, 0, 10, 1, 2, 2, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (2, 34, 24, 1, 3, 2, 0, 3, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (2, 35, 0, 0, 4, 2, 1, 3, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (2, 36, 5, 0, 3, 0, 0, 1, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (2, 37, 4, 0, 5, 0, 1, 1, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (2, 38, 0, 1, 0, 1, 0, 1, getdate())




insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (2, 15, 27, 0, 2, 0, 1, 1, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (2, 22, 31, 3, 6, 3, 1, 4, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (2, 21, 2, 1, 4, 1, 0, 3, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (2, 19, 20, 1, 8, 0, 2, 2, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (2, 20, 8, 0, 3, 0, 0, 1, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (2, 16, 7, 3, 5, 0, 0, 1, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (2, 17, 5, 1, 7, 0, 1, 3, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (2, 18, 1, 1, 6, 1, 0, 1, getdate())


-- 76ers vs Clippers


insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (3, 39, 26, 2, 9, 0, 1, 3, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (3, 40, 26, 10, 12, 1, 0, 3, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (3, 41, 9, 3, 6, 0, 2, 2, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (3, 42, 17, 5, 12, 0, 0, 0, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (3, 43, 6, 1, 1, 1, 1, 0, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (3, 44, 21, 1, 5, 0, 2, 3, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (3, 45, 3, 1, 4, 1, 0, 3, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (3, 46, 2, 0, 0, 0, 1, 1, getdate())




insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (3, 15, 30, 9, 4, 1, 2, 3, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (3, 16, 11, 5, 12, 0, 1, 3, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (3, 17, 0, 0, 0, 0, 0, 0, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (3, 18, 10, 1, 6, 0, 0, 4, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (3, 19, 19, 1, 0, 0, 0, 1, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (3, 20, 13, 6, 2, 1, 0, 2, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (3, 21, 7, 2, 8, 0, 2, 4, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (3, 22, 13, 1, 5, 0, 1, 1, getdate())


-- Nets vs Lakers

insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (4, 23, 3, 0, 7, 0, 1, 2, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (4, 24, 23, 7, 4, 1, 0, 4, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (4, 25, 22, 4, 7, 1, 1, 0, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (4, 26, 13, 2, 2, 1, 0, 1, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (4, 27, 7, 0, 6, 1, 1, 0, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (4, 28, 8, 1, 12, 0, 0, 2, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (4, 29, 12, 2, 3, 0, 0, 2, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (4, 30, 11, 5, 1, 0, 0, 0, getdate())


insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (4, 31, 29, 9, 12, 1, 0, 3, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (4, 32, 26, 2, 8, 0, 1, 4, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (4, 33, 14, 1, 5, 1, 0, 4, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (4, 34, 10, 2, 2, 0, 0, 3, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (4, 35, 6, 4, 2, 2, 0, 1, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (4, 36, 4, 0, 3, 1, 1, 3, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (4, 37, 0, 1, 6, 1, 1, 2, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (4, 38, 3, 1, 2, 1, 0, 2, getdate())



-- Lakers vs 76ers


insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (5, 31, 29, 8, 7, 1, 0, 3, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (5, 32, 31, 2, 7, 2, 1, 5, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (5, 33, 4, 2, 5, 0, 0, 1, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (5, 34, 7, 1, 1, 1, 0, 0, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (5, 35, 2, 1, 5, 2, 0, 0, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (5, 36, 2, 0, 5, 0, 0, 0, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (5, 37, 3, 0, 1, 0, 0, 1, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (5, 38, 4, 3, 1, 6, 0, 1, getdate())

insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (5, 39, 16, 1, 6, 1, 0, 2, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (5, 40, 28, 8, 10, 4, 0, 5, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (5, 41, 7, 3, 9, 1, 0, 2, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (5, 42, 29, 1, 8, 0, 1, 3, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (5, 43, 9, 3, 2, 1, 1, 3, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (5, 44, 6, 1, 1, 5, 1, 2, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (5, 45, 2, 4, 0, 0, 0, 2, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (5, 46, 9, 1, 0, 0, 0, 3, getdate())


-- 76ers vs Nets

insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (6, 39, 19, 2, 6, 0, 2, 3, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (6, 40, 34, 12, 12, 5, 2, 3, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (6, 41, 15, 4, 2, 1, 0, 1, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (6, 42, 15, 0, 6, 1, 1, 3, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (6, 43, 8, 0, 8, 0, 0, 0, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (6, 44, 5, 1, 0, 0, 0, 1, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (6, 45, 3, 1, 1, 0, 0, 2, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (6, 46, 3, 3, 4, 4, 1, 2, getdate())

insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (6, 23, 13, 2, 13, 1, 1, 2, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (6, 24, 22, 7, 5, 1, 0, 5, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (6, 25, 12, 1, 12, 1, 1, 2, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (6, 26, 15, 2, 4, 0, 0, 0, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (6, 27, 16, 6, 6, 0, 0, 2, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (6, 28, 2, 1, 1, 0, 0, 0, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (6, 29, 12, 1, 3, 0, 0, 4, getdate())
insert into dbo.Stats (GameId, PlayerId, Points, Assists, Rebounds, Blocks, Steals, Fouls, CreatedDate) 
				values (6, 30, 0, 0, 0, 0, 0, 0, getdate())