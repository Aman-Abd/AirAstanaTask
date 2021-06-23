export class Person {
  constructor(
    public Login?: string,
    public Password?: string,
    public Role: string = 'admin'    
  ) { }
}
