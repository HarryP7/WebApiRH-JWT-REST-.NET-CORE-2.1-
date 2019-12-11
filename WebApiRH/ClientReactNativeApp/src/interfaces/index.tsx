export interface User{
    uid: string,
    fullName: string,
    avatar: ImageUrl,
    fk_Role: number,
    fk_Home: string,    
    fk_Avatar: string,
    //login: string,
    // fk_Gender: number,
    // createdAt: Date,
    // editedAt: Date,
    //removed: boolean,
  }
  export interface ImageUrl {
    uid: string,
    url: string,
    createdAt: string,
    removed: boolean,
  }
  export interface Home {
    uid: string,
    location: string,
    fk_Admin: string,
    fk_Image: string,
    fk_Status: number,
    appartaments: number,
    floors: number,
    porches: number,
    yearCommissioning: string,
    createdAt: Date,
    editedAt: Date,
    removed: boolean
    imageUrl: ImageUrl
    tenants:User[],
    localGroups: Group[]
  }
  
interface Group{
  uid: string,
}