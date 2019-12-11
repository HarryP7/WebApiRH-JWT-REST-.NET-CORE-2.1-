import {createStackNavigator} from 'react-navigation-stack';
import {GroupLIST, GroupPRO, AUTH, HOMEScreen, AddHOME, AddGROUP, AddADVERT} from './routes'
import { GroupProfile, AuthScreen, HomeScreen, AddHomeScreen, AddGroupScreen, AddAdvertScreen} from './components'
import GroupScreen from './Navigation'


export default createStackNavigator(
    {
        [GroupLIST]: GroupScreen,
        [GroupPRO]: GroupProfile,
        [AUTH]: AuthScreen,
        [AddHOME]: AddHomeScreen,
        [HOMEScreen]: HomeScreen,
        [AddGROUP]: AddGroupScreen,
        [AddADVERT]: AddAdvertScreen
    },
    {
        //initialRouteName: GroupLIST,
        headerMode: 'none'
    }
)
