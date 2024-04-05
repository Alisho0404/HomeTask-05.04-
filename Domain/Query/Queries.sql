using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Query
{
    class Queries
    { 
      create table users
(
    id serial primary key, 
	firstname varchar(50),
	lastname varchar(50),
	phone varchar(50),
	email varchar(50)
)  
insert into users(firstname,lastname,phone,email)values('','','','') 
update users set firstname='',lastname='',phone='',email='' where id=
-------------------------------------------------------------------------
create table posts
(
   id serial primary key,
	authorid int references users(id),
	title varchar(50),
	published date
)  
insert into posts(authorid,title,published)values(,'','') 
update posts set authorid=,title='',published='' where id=
----------------------------------------------------------------------------
create table PostComments
(
    id serial primary key,
	postid int references posts(id),
	title varchar(50),
	published date
)  
insert into PostComments(postid,title,published)values(,'','')
update PostComments set postid=,title='',published='' where id=
---------------------------------------------------------------------------
create table tags
(
    id serial primary key,
	title varchar(50),
	slug varchar(50)
)  
insert into tags(title,slug)values('','') 
update tags set title='',slug='' where id=
----------------------------------------------------------------------------
create table posttag
(
    id serial primary key,
	postid int references posts(id),
	tagid int references tags(id)
) 
insert into posttag(postid,tagid)values(,) 
update posttag set postid=,tagid= where id= 
-----------------------------------------------------------------------------
create table category
(
   id serial primary key,
	title varchar(50),
	slug varchar(50),
	content text
)  
insert into category(title,slug,content)values('','','') 
update category set title='',slug='',content='' where id= 
------------------------------------------------------------------------------
create table postCtaegory
(
   id serial primary key,
	postid int references posts(id),
	categoryId int references category(id)
)  
insert into postCtaegory(postid,categoryId)values(,) 
update postCtaegory set postid=,categoryId= where id=
------------------------------------------------------------------------------
create table postmeta
(
    id serial primary key, 
	postid int references posts(id),
	key varchar(50),
	content text
)  
insert into postmeta(postid,key,content)values(,'','') 
Update postmeta set postid=,key='',content='' where id=

    }
}
