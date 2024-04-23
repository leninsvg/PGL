import { Component } from '@angular/core';
import { ClientsComponent } from '../../modules/client/components/clients/clients.component';

@Component({
  selector: 'app-clients-page',
  standalone: true,
  imports: [
    ClientsComponent
  ],
  templateUrl: './clients-page.component.html',
  styleUrl: './clients-page.component.scss'
})
export class ClientsPageComponent {

}
