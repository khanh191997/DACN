//module
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import{AppRoutingModule} from './app-routing.modules';
import{HttpClientModule} from '@angular/common/http';
//layout
import { AppComponent } from './app.component';
import { HeaderComponent } from './Components/layout/header/header.component';
import { MenuComponent } from './Components/layout/menu/menu.component';
import { FooterComponent } from './Components/layout/footer/footer.component';
//pages

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    MenuComponent,
    FooterComponent
    
  ],
  imports: [
    BrowserModule,AppRoutingModule,HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
