import { Component, OnInit } from '@angular/core';
import { IItem } from '../items/item';
import { ItemsService } from '../items/items.service';
import { IItemDetalle } from './item-detalle';
import { IConstruction } from '../construction/construction';
import { ConstructionService } from '../construction/construction.service';

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
  total: number = 0;
  // Esto a cambiar si es que en algun momento se puede editar
  constructionId: number= 0;

  constructor(private itemsService: ItemsService,
    private constructionService: ConstructionService) {
    itemsService.getItems()
      .subscribe(items => this.items = items,
        error => console.error(error));
  }

  ngOnInit() {
  }

  onSelectItem() {
    let itemDetalle: IItemDetalle;

    itemDetalle = {
      id: 0,
      itemId: this.itemId,
      item: this.items.find(x => x.id == this.itemId),
      quantity: this.quantity,
    };
    this.itemsDetalle.push(itemDetalle);
    this.calcular();
  }
  quitarDeTabla(index: number) {
    this.itemsDetalle.splice(index, 1);
    this.calcular();
  }

  calcular() {
    this.total = this.itemsDetalle.reduce((sum, value) => (sum + value.item.price * value.quantity), 0);
  }

  update() {
    let construction: IConstruction;
    console.log("que hago aca");
    //Elimino los items para que no tener problemas al hacer el add de construction
    var array = this.itemsDetalle;
    array.forEach(function (element) {
      element.item = undefined;
    });
   
    console.log(this.itemsDetalle);
    construction = {
      id: this.constructionId,
      name: "prueba",
      startDate: new Date(),
      endDate: new Date(),
      cost:this.total,
      itemsDetalle:array,
    };


    console.log(construction);
    this.constructionService.createConstruction(construction)
      .subscribe(() => console.log("Guardado"),
        error => console.error(error));

  }

}
