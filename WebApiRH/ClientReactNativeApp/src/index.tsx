import {createStackNavigator} from 'react-navigation-stack';
import {NotAuthNAVIGATION,NAVIGATIONAdmin, NAVIGATIONUser, GroupLIST, 
    GroupPRO, AUTH, REGISTRATION, ADDRESSScreen, HOMEProfile, AddHOME,SEARCHHomeScreen, AddGROUP, 
    AddADVERT} from './routes'
import {GroupScreen, GroupProfile, AuthScreen, RegistrationScreen, AddressScreen, HomeProfile, AddHomeScreen, 
    AddGroupScreen, AddAdvertScreen, SearchHomeScreen} from './components'
import NotAuthNavigation from './NotAuthNavigation'
import NavigationAdmin from './NavigationAdmin'
import NavigationUser from './NavigationUser'


export default createStackNavigator(
    {
        [NotAuthNAVIGATION]: NotAuthNavigation,
        [NAVIGATIONAdmin]: NavigationAdmin,
        [NAVIGATIONUser]: NavigationUser,
        [HOMEProfile]: HomeProfile,
        [GroupLIST]: GroupScreen,
        [GroupPRO]: GroupProfile,
        [AUTH]: AuthScreen,
        [REGISTRATION]: RegistrationScreen,
        [ADDRESSScreen]: AddressScreen,
        [AddHOME]: AddHomeScreen,
        [AddGROUP]: AddGroupScreen,
        [AddADVERT]: AddAdvertScreen,
        [SEARCHHomeScreen]: SearchHomeScreen
    },
    {
        //initialRouteName: GroupLIST,
        headerMode: 'none'
    }
)
