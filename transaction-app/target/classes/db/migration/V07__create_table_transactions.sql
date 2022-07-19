create table if not exists transactions(
id varchar(255) not null,
account varchar(255) not null,
description varchar(255) not null,
type varchar(255) not null,
value float8 not null,
primary key (id));
