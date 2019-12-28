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
  
  export interface Group {
    uid: string,
    title: string,
    fk_Admin: string,
    fk_Image: string,
    fk_Status: number,
    fk_Home: string,
    createdAt: Date,
    editedAt: Date,
    removed: boolean
  }
  export interface AuthData {
    token: string,
    userLogin: User,
  }
  export interface arrText {
    login: string,
    name: string,
    surname: string,
    password: string,
    repeatPassword: string
  };
  export interface arrBool {
    login: boolean,
    name: boolean,
    surname: boolean,
    password: boolean,
    repeatPassword: boolean
  };
  export interface adrText {
    city: string,
    street: string,
    home: string,
    appartment: string,
  };
  export interface adrBool {
    city: boolean,
    street: boolean,
    home: boolean,
    appartment: boolean,
  };