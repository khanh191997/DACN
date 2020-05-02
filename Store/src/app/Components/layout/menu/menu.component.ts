import { Component, OnInit } from '@angular/core';
import{CategoryService} from '../../../Services/category.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css'],
  providers:[CategoryService]
})
export class MenuComponent implements OnInit {

  arrCate:any=[]
  constructor( private cateservice:CategoryService) {

    cateservice.getCategory().subscribe(data=>{
      console.log(data);
      this.arrCate=data;
    });
   }

  ngOnInit(): void {
  }

}
