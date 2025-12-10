drop schema if exists dead_pigeons cascade;
create schema if not exists dead_pigeons;

create table dead_pigeons.players(
                                     id uuid primary key,
                                     name text not null,
                                     phone text not null,
                                     email text not null,
                                     created_at timestamp with time zone not null,
                                     is_active boolean default true not null
);

create table dead_pigeons.users(
                                   id uuid primary key,
                                   name text not null,
                                   password_hash text not null,
                                   role text not null,
                                   created_at timestamp with time zone not null
);

-- Supporting transactions enumeration table
create type txn_status as enum ('pending', 'approved', 'rejected');

create table dead_pigeons.transactions(
                                          id uuid primary key,
                                          player_id uuid references dead_pigeons.players(id) not null,
                                          amount numeric(10,2) not null,
                                          status txn_status not null default 'pending',
                                          created_at timestamp without time zone not null default now()
);
