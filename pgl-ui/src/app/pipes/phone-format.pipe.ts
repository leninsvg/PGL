import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'phoneFormat',
  standalone: true
})
export class PhoneFormatPipe implements PipeTransform {

  transform(phoneNumber: string): string {
    const phoneFragments = phoneNumber.split('');
    let resultPhone = '';
    for (let i = 0; i < phoneFragments.length; i++) {
      resultPhone += phoneFragments[i];
      if ((i + 1) === phoneFragments.length) {
        break;
      }
      if ((i + 1) % 4 === 0) {
        resultPhone += ' ';
      }
    }
    return resultPhone;
  }
}
