import { Component } from '@angular/core';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;

  toggleNav() {
    if(this.isExpanded==false){
      document.getElementById("sidebar").style.width = "250px";
      document.getElementById("main").style.marginLeft = "250px";

      this.isExpanded=true;

      console.log(this.isExpanded);
    }else{
      document.getElementById("sidebar").style.width = "0";
      document.getElementById("main").style.marginLeft = "0";

       this.isExpanded=false;
       console.log(this.isExpanded);
    }
  }
}
