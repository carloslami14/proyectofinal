import { Component, OnInit } from '@angular/core';
import { IItem } from '../items/item';
import { ItemsService } from '../items/items.service';

@Component({
  selector: 'app-calculation',
  templateUrl: './calculation.component.html',
  styleUrls: ['./calculation.component.css']
})
export class CalculationComponent implements OnInit {

  items: IItem[] = [];


  constructor(private itemsService: ItemsService) {
    itemsService.getItems()
      .subscribe(items => this.items = items,
        error => console.error(error));
  }

  ngOnInit() {
  }

}
