import * as React from 'react';
import {
  View,Text, ScrollView, ActivityIndicator } from 'react-native';
import { Header, SearchBar, GroupCard,  styles } from '..';
import {  menu, search } from '../../allSvg'
import { GroupPRO } from '../../routes';
import { brown } from '../../constants';

interface Group {
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

interface State {
  data: Group[],
  load: boolean,
  visibleSearch: boolean,
}

class GroupScreen extends React.Component<any, State> {
  state = { data: [], load: false, visibleSearch: false } as State
  
  componentDidMount = async () => {
    try {
      const token = '';
      const response = await fetch('http://192.168.43.80:5000/api/groups')
      const data = await response.json()
      this.setState({ data, load: true })
    } catch (e) {
      throw e
    }
  }

  _onChangeText = (text: string) => {
    //console.log('text ' + text)
    this.props.searchChanged(text)
  }

  render() {
    const { data, load, visibleSearch } = this.state
    const dataR = [{ "admin": null, "adverts": [Array], "createdAt": "2019-11-15T00:00:00", "editedAt": "2019-11-15T00:00:00", "fk_Admin": "0000e0000-t0t-00t0-t000-00000000000", "fk_Home": null, "fk_Image": "5ddc6bd0-627b-42da-a603-d62adab55efe", "fk_Status": 1, "home": null, "image": { createdAt: "2019-11-15T00:00:00", removed: false, uid: "3f7d7280-dba7-4119-9cdf-71dd30647d6e", url: "https://i.ibb.co/c1Tc0Pp/house-1876063-960-720.jpg" }, "messages": [Array], "removed": false, "title": "Дом - Объявления", "uid": "3f685871-7ff7-4e1e-8280-f93064bd4f2a", "users": [Array] }, { "admin": null, "adverts": [Array], "createdAt": "2019-11-15T00:00:00", "editedAt": "2019-11-15T00:00:00", "fk_Admin": "0000e0000-t0t-00t0-t000-00000000000", "fk_Home": null, "fk_Image": "3f7d7280-dba7-4119-9cdf-71dd30647d6e", "fk_Status": 1, "home": null, "image": { createdAt: "2019-11-15T00:00:00", removed: false, uid: "5ddc6bd0-627b-42da-a603-d62adab55efe", url: "https://i.ibb.co/bQcGvqJ/yxz-Pf-v-Yy3g.jpg" }, "messages": [Array], "removed": false, "title": "1й подъезд - Объявления", "uid": "dac7bf05-4260-4d0f-9e32-d2eee80589db", "users": [Array] }]
    const { container, indicator } = styles
    const { navigation } = this.props
    console.log(this.props)
    return (<View>
      {visibleSearch ?
        <SearchBar           
          rightIcon={search}
          onChangeText={this._onChangeText}
          value={'подъезд'}
          onPressRight={() => this.setState({visibleSearch: false})}
          onBlur={() => this.setState({visibleSearch: false})}
        /> : 
        <Header title='Группы'
          leftIcon={menu}
          onPressLeft={() => {
            navigation.openDrawer()
          }}
          rightIcon={search}
          onPressRight={() => this.setState({visibleSearch: true})}
        />
      }
      <ScrollView>
        {load ?
          <View style={container}>
            {data.map(item => {
              return <GroupCard data={item} key={item.uid}
                onPress={() => navigation.navigate(GroupPRO, (item))} />//
            })}
          </View> :
          <ActivityIndicator style={indicator} size={50} color={brown} />
        }
        {load ?
          <View style={container}>
            {data.map(item => {
              return <GroupCard data={item} key={item.uid}
                onPress={() => navigation.navigate(GroupPRO, (item))} />//
            })}
          </View> :
          <ActivityIndicator style={indicator} size={50} color={brown} />
        }
        {load ?
          <View style={container}>
            {data.map(item => {
              return <GroupCard data={item} key={item.uid}
                onPress={() => navigation.navigate(GroupPRO, (item))} />//
            })}
          </View> :
          <ActivityIndicator style={indicator} size={50} color={brown} />
        }
        <View style={{margin: 30}}><Text></Text></View>
      </ScrollView>
    </View>
    );
  }
}

export default (GroupScreen) //connect(mapStateToProps,{searchChanged})