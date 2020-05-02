import { Component, OnInit } from '@angular/core';
import{CategoryService} from '../../../Services/category.service';

@Component({
  selector: 'app-cate',
  templateUrl: './cate.component.html',
  styleUrls: ['./cate.component.css'],
  providers:[CategoryService]
})
export class CateComponent implements OnInit {

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
