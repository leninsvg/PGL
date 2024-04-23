import { Routes } from '@angular/router';
import { ClientsComponent } from './modules/client/components/clients/clients.component';
import { ClientsPageComponent } from './Pages/clients-page/clients-page.component';

export const routes: Routes = [
  {
    path: '',
    component: ClientsPageComponent
  }
];
