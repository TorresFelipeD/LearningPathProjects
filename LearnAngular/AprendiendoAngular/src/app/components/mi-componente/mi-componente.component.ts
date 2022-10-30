import { Component } from "@angular/core";

@Component({
    selector:'mi-componente',
    templateUrl:'./mi-componente.component.html'
})
export class MiComponente{
    public titulo: string;
    public parrafo: string;

    constructor(){
        this.titulo = "Soy mi componente";
        this.parrafo = "Este es mi primer componente";
        console.log("Componente mi-componente cargado");
    }
}