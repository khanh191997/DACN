const express=require('express');
const path=require('path');
const cookieParser=require('cookie-parser');
const bodyParser=require('body-parser');
const hbs=require("express-handlebars");


const app=express();

//view engine setup    
app.engine('hbs',hbs({extname: 'hbs',defaultLayout:'layout',layoutsDir: __dirname + '/views/layouts'}));
app.set('views',path.join(__dirname,'views'));
app.set('view engine','hbs');


app.use(bodyParser.json());
app.use(bodyParser.urlencoded({extended: false}));
app.use(cookieParser());
app.use(express.static(path.join(__dirname,'public')));


app.listen(3000);
app.get("/",function(req,res){
    res.render('index',{title:'Trang chủ'});

});
app.get("/about.html",function(req,res){
    res.render('about',{title:'Giới thiệu'});

});



