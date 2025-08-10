import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { signal } from '@angular/core';

@Component({
  selector: 'app-labs',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './labs.component.html',
  styleUrl: './labs.component.css'
})
export class LabsComponent {
  welcome  = 'Hola!';
  tasks = [
    'Instalar el Angular CLI',
    'Crear Proyecto',
    'Crear Componentes'
  ]

  name = signal("Diego");
  disabled = true;
  img="https://w3schools.com/howto/img_avatar.png";

  person = {
    name:"Diego",
    age: 20,
    img:"https://w3schools.com/howto/img_avatar.png"
  }

  clickHandler(){
    alert('Hola');
  }

  changeHandler(event: Event){
    const input = event.target as HTMLInputElement;
    const newValue = input.value;
    this.name.set(newValue);
  }

  keydownHandler(event: KeyboardEvent){
    const input = event.target as HTMLInputElement;
    console.log(input.value);
  }

  keydownSignalHandler(event: KeyboardEvent){
    const input = event.target as HTMLInputElement;
    const newValue = input.value;
    this.name.set(newValue);
  }

  keyupHandler(event: KeyboardEvent){
    const input = event.target as HTMLInputElement;
    console.log(input.value);
  }
}
