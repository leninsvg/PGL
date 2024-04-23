import { Component, Input, OnInit } from '@angular/core';
import { PersonService } from '../../../../services/person.service';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { PageModel } from '../../../../models/page.model';
import { ClientModel } from '../../../../models/client.model';
import { lastValueFrom } from 'rxjs';
import { JsonPipe, NgForOf } from '@angular/common';
import { PhoneFormatPipe } from '../../../../pipes/phone-format.pipe';
import { DataBaseInteractionType } from '../../../../generic/custom.types';

@Component({
  selector: 'app-clients',
  standalone: true,
  imports: [
    NgForOf,
    PhoneFormatPipe,
    ReactiveFormsModule,
    JsonPipe
  ],
  templateUrl: './clients.component.html',
  styleUrl: './clients.component.scss'
})
export class ClientsComponent implements OnInit {

  @Input()
  public dataBaseInteractionType: DataBaseInteractionType;
  protected clientFilterForm: FormGroup;
  protected clients: PageModel<ClientModel>;
  protected pageSizes: number[];

  constructor(
    private personService: PersonService,
    private formBuilder: FormBuilder
  ) {
    this.initVariables();
  }

  ngOnInit(): void {
    this.getClients().then();
  }

  protected getClients = async (): Promise<void> => {
    const filter = this.clientFilterForm?.getRawValue();
    if (this.dataBaseInteractionType === 'EF') {
      this.clients = await lastValueFrom(this.personService.getClients(filter))

    } else if (this.dataBaseInteractionType === 'SP') {
      this.clients = await lastValueFrom(this.personService.getClientsSP(filter))
    }
  }

  protected increasePage = (value: number): void => {
    let page = this.clientFilterForm.get('page').value;
    page = page + value;
    this.clientFilterForm.get('page').setValue(page);
    this.getClients().then();
  }

  protected selectPage = (): void => {
    this.clientFilterForm.get('page').setValue(1);
    this.getClients().then();
  }

  private initVariables(): void {
    this.dataBaseInteractionType = 'EF';
    this.clients = {page: 1, pageSize: 10, totalItems: 0, totalPages: 0, items: []};
    this.pageSizes = [1, 5, 10];
    this.clientFilterForm = this.formBuilder.group({
      page: [1],
      pageSize: [10]
    });
  }
}
