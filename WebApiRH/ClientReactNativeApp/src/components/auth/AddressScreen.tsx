import React, { Component, useState, useEffect } from 'react';
import {
  StyleSheet, ScrollView, View, Text, TouchableOpacity, TextInput, Alert,
  ActivityIndicator, Picker, SafeAreaView
} from 'react-native';
import { SvgXml } from 'react-native-svg';
import { user, homeLoc, lock, lockRep, shield } from '../../allSvg'
import { Header } from '..';
import { h, w, brown } from '../../constants'
import { backArrow } from '../../allSvg'
import { User, adrText, adrBool } from '../../interfaces'
import { actions } from '../../store'
import { AUTH } from '../../routes';
import { CityList } from './CityList'
import { Icon } from 'react-native-elements'
import { GroupStatus } from '../../enum/Enums';

interface Props { }
interface State { }
interface AuthData {
  token: string,
  userAppartment: User,
}
var arrTxt: adrText = {
  city: '',
  street: '',
  home: '',
  appartment: '',
};
var arr: adrBool = {
  city: false,
  street: false,
  home: false,
  appartment: false,
};
var arrColor: adrText = {
  city: '',
  street: '',
  home: '',
  appartment: '',
};

class AddressScreen extends Component<any, State, Props> {
  state = {
    appartment: '', city: '', street: '', home: '',
    password: '', repeatPassword: '', color: brown,
     good: true, passGood: false, submit: false,
    badEnter: arr, errorText: arrTxt, colorIcon: arrColor,
    
  }

  render() {
    console.log('Props AddresScreen', this.props)
    const {appartment, city, street, home, color,
      badEnter, errorText, colorIcon, submit,
      good } = this.state
    const { navigation } = this.props
    const { fixToText, icon, textInput, input, button, buttonContainer, buttonTitle, indicator,
      link, error, inputMultiline } = styles
    console.log('good', good)
    let dataStatus = [{
      value: GroupStatus.Public,
    }, {
      value: GroupStatus.Pravite,
    },];
    return (
      <View>
        <Header title={'Адрес дома'}
          leftIcon={backArrow}
          onPressLeft={() => {
            //this.setClearState()
            navigation.goBack();
          }}
        />
        <ScrollView>
          {submit && <ActivityIndicator style={indicator} size={70} color="#92582D" />}

          <View>
            <View style={fixToText}>
              <SvgXml xml={homeLoc} style={icon} fill={color} />
              <View style={textInput}>
                <TextInput
                  style={inputMultiline}
                  onChangeText={this.onChangeCity.bind(this)}
                  placeholder='Город'
                  autoCorrect={true}
                  value={city}
                  multiline={true}
                  numberOfLines={1}
                  onEndEditing={() => this.onCheckCity(city)}
                />
                {badEnter.city && <Text style={error}>{errorText.city}</Text>}
              </View>
            </View>

            <View style={fixToText}>
              <SvgXml xml={homeLoc} style={icon} fill={color} />
              <View style={textInput}>
                <Picker
                  style={inputMultiline}
                  selectedValue={city}
                  onValueChange={(itemValue, itemIndex) =>
                    this.setState({ city: itemValue })
                  }>
                  <Picker.Item label="Готем Сити" value="Готем Сити" />
                  <Picker.Item label="Тайная цитадель" value="Тайная цитадель" />
                </Picker>
                {badEnter.city && <Text style={error}>{errorText.city}</Text>}
              </View>
            </View>

            <View style={fixToText}>
              <SvgXml xml={user} style={icon} fill={color} />
              <View style={textInput}>
                <TextInput
                  style={input}
                  onChangeText={this.onChangeStreet.bind(this)}
                  placeholder='Улица'
                  value={street}
                  onEndEditing={() => this.onCheckStreet(street)}
                />
                {badEnter.street && <Text style={error}>{errorText.street}</Text>}
              </View>
            </View>

            <View style={fixToText}>
              <SvgXml xml={user} style={icon} fill={color} />
              <View style={textInput}>
                <TextInput
                  style={input}
                  onChangeText={this.onChangeHome.bind(this)}
                  placeholder='Номер дома'
                  value={home}
                  onEndEditing={() => this.onCheckHome(home)}
                  keyboardType='number-pad'
                />
                {badEnter.home && <Text style={error}>{errorText.home}</Text>}
              </View>
            </View>

            <View style={fixToText}>
              <SvgXml xml={user} style={icon} fill={color} />
              <View style={textInput}>
                <TextInput
                  style={input}
                  onChangeText={this.onChangeAppartment.bind(this)}
                  placeholder='Кваритира'
                  value={appartment}
                  onEndEditing={() => this.onCheckAppartment(appartment)}
                  keyboardType='number-pad'
                />
                {badEnter.appartment && <Text style={error}>{errorText.appartment}</Text>}
              </View>
            </View>
          </View>

          <View style={{ alignItems: 'center' }}>
            <View style={button}>
              <TouchableOpacity
                onPress={this.onSubmit.bind(this)}
                disabled={submit} >
                <View style={buttonContainer}>
                  <Text style={buttonTitle}>Подтверить</Text>
                </View>
              </TouchableOpacity>
            </View>
          </View>

          <View style={{ margin: 50 }}><Text> </Text></View>
        </ScrollView>
      </View>
    );
  }

  private onChangeAppartment(appartment: string) {
    var badEnter = this.state.badEnter
    var errorText = this.state.errorText
    if (appartment == ' ') { return }
    if (!appartment) {
      badEnter.appartment = true;
      errorText.appartment = 'Поле не заполнено!'
      this.setState({ badEnter, errorText, appartment, good: false });
      return;
    }
    else {
      badEnter.appartment = false;
      this.setState({ appartment });
    }
  }
  private onCheckAppartment(appartment: string) {
    var badEnter = this.state.badEnter
    var errorText = this.state.errorText
    if (appartment.length < 4 || appartment.length > 20) {
      badEnter.appartment = true;
      errorText.appartment = 'Логин должен быть длиной от 4 до 20 символов!'
      this.setState({ badEnter, errorText, appartment, good: false });
      return;
    }
    else {
      badEnter.appartment = false;
      this.setState({ appartment, badEnter });
    }
  }
  private onChangeCity(city: string) {
    var badEnter = this.state.badEnter
    var errorText = this.state.errorText
    if (city == ' ') { return }
    if (!city) {
      badEnter.city = true;
      errorText.city = 'Поле не заполнено!'
      this.setState({ badEnter, errorText, city, good: false });
      return;
    }
    else {
      badEnter.city = false;
      this.setState({ city });
    }
  }
  private onCheckCity(city: string) {
    var badEnter = this.state.badEnter
    var errorText = this.state.errorText
    if (city.length < 2) {
      badEnter.city = true;
      errorText.city = 'Введите полный адрес!'
      this.setState({ badEnter, errorText, city, good: false });
      return;
    }
    else {
      badEnter.city = false;
      this.setState({ city, badEnter });
    }
  }
  private onChangeStreet(street: string) {
    var badEnter = this.state.badEnter
    var errorText = this.state.errorText
    if (street == ' ') { return }
    if (!street) {
      badEnter.street = true;
      errorText.street = 'Поле не заполнено!'
      this.setState({ badEnter, errorText, street, good: false });
      return;
    }
    else {
      badEnter.street = false;
      this.setState({ street, good: true });
    }
  }
  private onCheckStreet(street: string) {
    var badEnter = this.state.badEnter
    var errorText = this.state.errorText
    if (street.length < 2 || street.length > 25) {
      badEnter.street = true;
      errorText.street = 'Имя должно быть больше 1 символа и меньше 25!'
      this.setState({ badEnter, errorText, street, good: false });
      return;
    }
    else {
      badEnter.street = false;
      this.setState({ street, badEnter });
    }
  }
  private onChangeHome(home: string) {
    var badEnter = this.state.badEnter
    var errorText = this.state.errorText
    if (home == ' ') { return }
    if (!home) {
      badEnter.home = true;
      errorText.home = 'Поле не заполнено!'
      this.setState({ badEnter, errorText, home, good: false });
      return;
    }
    else {
      badEnter.home = false;
      this.setState({ home });
    }
  }
  private onCheckHome(home: string) {
    var badEnter = this.state.badEnter
    var errorText = this.state.errorText
    var colorIcon = this.state.colorIcon
    if (home.length < 2 || home.length > 25) {
      badEnter.home = true;
      errorText.home = 'Фамилия должна быть больше 1 символа и меньше 25!'
      this.setState({ badEnter, errorText, home, good: false });
      return;
    }
    else {
      badEnter.home = false;
      colorIcon.home = 'green'
      this.setState({ home, badEnter, colorIcon });
    }
  }
  


  private onSubmit() {
    const {  appartment, city, street, home, badEnter, errorText,
      colorIcon, good } = this.state
    const { navigation } = this.props
    var $this = this;
    var obj, url, log: string;
    
      if (!city) {
        badEnter.city = true;
        errorText.city = 'Поле не заполнено!'
        colorIcon.city = 'red'
        this.setState({ badEnter, errorText, colorIcon, good: false });
      }
      if (!street) {
        badEnter.street = true;
        errorText.street = 'Поле не заполнено!'
        colorIcon.appartment = 'red'
        this.setState({ badEnter, errorText, colorIcon, good: false });
      }
      if (!home) {
        badEnter.home = true;
        errorText.home = 'Поле не заполнено!'
        colorIcon.home = 'red'
        this.setState({ badEnter, errorText, colorIcon, good: false });
      }      
    if (!appartment) {
      badEnter.appartment = true;
      errorText.appartment = 'Поле не заполнено!'
      colorIcon.appartment = 'red'
      this.setState({ badEnter, errorText, colorIcon, good: false });
    }
     
      if (badEnter.appartment || badEnter.city || badEnter.street || badEnter.home ) {
        // var txt = 'Поля не валидны!'        
        this.setState({ good: false }); //, isVisible: true, textOverlay: txt 
        Alert.alert('Внимание', 'Заполните поля правильно!',
          [{ text: 'OK' }]);

        return;
      }
      else this.setState({ good: true });

     obj = {
        Appartment: appartment,
        //Addres: city,
        FullStreet: street + ' ' + home,
        
        Role: 2
      }
      url = 'http://192.168.43.80:5000/api/auth/signup/';
      log = 'Адрес дома'
    
    if (good) {
      this.setState({ submit: true })
      fetch(url, {
        method: 'POST', // *GET, POST, PUT, DELETE, etc.
        headers: {
          'Accept': "application/json",
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(obj), //JSON.stringify(
      })
        .then(function (response) {
          if (response.status == 200 || response.status == 201) {
            console.log('Успех ' + log + ' Post статус: ' + response.status + ' ok: ' + response.ok);
            console.log(response);
            
              Alert.alert('Данные сохранены!', 'Пожалуйста, войдите в систему используя свой логин и пароль',
                [{ text: 'OK' }]);
              $this.setState({ twoStap: true })
              $this.setClearState();
              return response.json();
            
          }
          if (response.status == 500) {
            console.log('Server Error', "Status: " + response.status + ' ' + response)
            Alert.alert('Внимание', 'Ошибка сервера!',
              [{ text: 'OK' }]);
          }
          if (response.status == 400) {
            console.log('Bad Request', "Status: " + response.status + ' ' + response)
            Alert.alert('Внимание', 'Логин или пароль не верны!',
              [{ text: 'OK' }]);
          }
        })
        .then(function (data: AuthData) {          
            console.log('data: ', data);
            navigation.navigate(AUTH);
          
        })
        .catch(error => {
          console.log('Внимание', 'Ошибка ' + log + ' Post fetch: ' + error);
          Alert.alert('Внимание', 'Ошибка ' + log + ' Post fetch: ' + error, [{ text: 'OK' }]);
          $this.setClearState();
        });
    }
    else {
      Alert.alert('Внимание', 'Заполните поля правильно!',
        [{ text: 'OK' }],
        { cancelable: false },
      );
      return;
    }
  }
  private setClearState() {
    var arrTxt: adrText = {
      city: '',
      street: '',
      home: '',
      appartment: '',
    };
    var arr: adrBool = {
      city: false,
      street: false,
      home: false,
      appartment: false,
    };
    this.setState({
      appartment: '', city: '', street: '', home: '',
      password: '', repeatPassword: '', color: brown,
      signup: false, good: true, passGood: false, submit: false,
      badEnter: arr, colorIcon: arrColor,
    })
  }
}

const styles = StyleSheet.create({
  icon: {
    width: 35,
    height: 35,
    marginRight: 10,
  },
  textInput: {
    width: w * 0.8,
  },
  input: {
    borderColor: 'gray',
    borderWidth: 1,
    borderRadius: 10,
    padding: 10,
    height: 40,
  },
  inputAutoC: {
    maxHeight: 40
  },
  plus: {
    position: "absolute",
    left: 15,
    top: 10,
  },
  autocompletesContainer: {
    paddingTop: 0,
    zIndex: 1,
    width: w * 0.9,
    paddingHorizontal: 8,
  },
  inputMultiline: {
    borderColor: 'gray',
    borderWidth: 1,
    borderRadius: 10,
    paddingHorizontal: 10,
    paddingVertical: 5,
    alignContent: 'flex-start',
  },
  flex: {
    margin: 120,
    textAlign: 'center',
    justifyContent: 'flex-end',
    paddingBottom: 200,
  },
  fixToText: {
    marginTop: 20,
    flexDirection: 'row',
    justifyContent: 'center',
  },
  button: {
    marginTop: 20,
    width: 250,
  },
  buttonContainer: {
    backgroundColor: '#92582D',
    height: 40,
    alignItems: 'center',
    justifyContent: 'center',
    borderRadius: 7,
  },
  buttonTitle: {
    fontSize: 18,
    color: '#fff',
  },
  link: {
    marginVertical: 20,
    color: '#92582D',
    textAlign: 'center',
    fontSize: 20,
  },
  error: {
    marginTop: 5,
    color: 'red',
    marginBottom: -10
  },
  indicator: {
    marginTop: 50,
    position: 'absolute',
    alignSelf: 'center',
  },
})

export { AddressScreen };