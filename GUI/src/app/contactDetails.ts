export class ContactDetails
{
    IdContactDetails?:number;
    FirstName?:string;
    LastName?:string;
    PhoneNo?:number;
    Email?:string;
    IsActive?:number;
    CreatedBy?:number;
    CreatedOn?:Date;
    updatedBy?:number;
    updatedOn?:Date;
}

export class ResultMessage
{
  public  Exception?:Error
  public  Tag?:Object
  public  MessageType?:ResultMessageE
  public  Text?:string
  public  Result?:number
  public DisplayMessage?: string

}

export enum ResultMessageE {
    None = 0,
    Information = 1,
    Error = 2
}
