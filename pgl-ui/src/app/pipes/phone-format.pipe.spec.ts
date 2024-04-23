import { PhoneFormatPipe } from './phone-format.pipe';

describe('PhoneFormatPipe', () => {
  it('create an instance', () => {
    const pipe = new PhoneFormatPipe();
    expect(pipe).toBeTruthy();
  });

  it('validate format validation', () => {
    const pipe = new PhoneFormatPipe();
    const result =  pipe.transform('+59398373266');
    expect(result).toBe('+593 9837 3266');
  });
});
