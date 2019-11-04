import { Component, OnInit } from '@angular/core';
import { IItem } from '../items/item';
import { ItemsService } from '../items/items.service';
import { IItemDetalle } from './item-detalle';

@Component({
  selector: 'app-calculation',
  templateUrl: './calculation.component.html',
  styleUrls: ['./calculation.component.css']
})
export class CalculationComponent implements OnInit {

  items: IItem[] = [];
  itemsDetalle: IItemDetalle[] = [];
  itemId: number=0;
  quantity: number = 0;

  constructor(private itemsService: ItemsService) {
    itemsService.getItems()
      .subscribe(items => this.items = items,
        error => console.error(error));
  }

  ngOnInit() {
  }

  onSelectItem() {
    let itemDetalle: IItemDetalle;
    console.log(itemDetalle);

    itemDetalle = {
      itemId: this.itemId,
      item: this.items.find(x => x.id == this.itemId),
      quantity: this.quantity,
    };
    this.itemsDetalle.push(itemDetalle);
  }
  quitarDeTabla(itemId: number) {
    this.itemsDetalle = this.itemsDetalle.filter(x => x.itemId != itemId);
  }

}
