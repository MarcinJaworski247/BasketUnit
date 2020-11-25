insert into Nationalities values ('USA')
insert into Nationalities values ('Brazylia')
insert into Nationalities values ('Argentyna')
insert into Nationalities values ('Kanada')
insert into Nationalities values ('Australia')
insert into Nationalities values ('Francja')
insert into Nationalities values ('Hiszpania')


insert into WorkoutTypes (Name, CreatedDate) values ('Si�ownia', getdate())
insert into WorkoutTypes (Name, CreatedDate) values ('Bieganie', getdate())
insert into WorkoutTypes (Name, CreatedDate) values ('Koz�owanie', getdate())
insert into WorkoutTypes (Name, CreatedDate) values ('Taktyka', getdate())
insert into WorkoutTypes (Name, CreatedDate) values ('Trening rzutowy', getdate())


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


insert into Teams (Name, City, ArenaId, CreatedDate) values ('Clippers', 'Los Angeles', 1, getdate())
insert into Teams (Name, City, ArenaId, CreatedDate) values ('Nets', 'Brooklyn', 2, getdate())
insert into Teams (Name, City, ArenaId, CreatedDate) values ('Warriors', 'Golden State', 3, getdate())
insert into Teams (Name, City, ArenaId, CreatedDate) values ('Pelicans', 'New Orleans', 4, getdate())
insert into Teams (Name, City, ArenaId, CreatedDate) values ('Rockets', 'Houston', 5, getdate())
insert into Teams (Name, City, ArenaId, CreatedDate) values ('Lakers', 'Los Angeles', 6, getdate())
insert into Teams (Name, City, ArenaId, CreatedDate) values ('Celtics', 'Boston', 7, getdate())
insert into Teams (Name, City, ArenaId, CreatedDate) values ('Heat', 'Miami', 8, getdate())
insert into Teams (Name, City, ArenaId, CreatedDate) values ('76ers', 'Philadelphia', 9, getdate())
insert into Teams (Name, City, ArenaId, CreatedDate) values ('Knicks', 'New York', 10, getdate())