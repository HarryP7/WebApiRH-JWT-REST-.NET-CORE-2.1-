import React, { Component } from 'react';
import {
  StyleSheet, ScrollView, View, Text, TouchableOpacity, TouchableWithoutFeedback,
  Button,  Alert
} from 'react-native';
import { SvgXml } from 'react-native-svg';
import { save } from '../../allSvg'
import { Header } from '..';//, styles 
import { Dropdown } from 'react-native-material-dropdown';
import { h, w } from '../../constants'
import { HomeStatus } from '../../enum/Enums'
import { backArrow } from '../../allSvg'
import { TextInput } from 'react-native-gesture-handler';
//import { createStyles, makeStyles, Theme } from '@material-ui/core/styles';
//import {Fab} from '@material-ui/core';
//import Save from '@material-ui/icons/Save';

interface Props { }
interface State { }
var arr: boolean[] = [];
for (var i = 0; i <= 6; i++) {
  arr.push(false);
}
var arrText: string[] = [];
for (var i = 0; i <= 6; i++) {
  arrText.push('');
}
var year = new Date().getFullYear().toString();

class AddHomeScreen extends Component<any, State, Props> {
  state = {
    appartament: '', address: '', floors: '', porches: '',
    year: year, status: '', colorText: '#000',
    good: true, signup: false, badEnter: arr.slice(),
    errorText: arrText.slice()
  }

  render() {
    console.log('Props AddHomeScreen', this.props)
    const { signup, appartament, address, floors, porches, year, colorText,
      good, status, badEnter, errorText } = this.state
    const { navigation } = this.props
    const { container, fixToText, label, label2, textInput, textInput2,
      inputMultiline, input,
      button, buttonContainer, buttonTitle, error } = styles
    let dataStatus = [{
      value: HomeStatus.Exploited,
    }, {
      value: HomeStatus.Emergency,
    },];
    return (<View>
      <Header title='Добавить дом'
        leftIcon={backArrow}
        onPressLeft={() => {
          this.setClearState();
          navigation.goBack();
        }} />
      <ScrollView>
        <View style={container}>
          <View style={fixToText}>
            <View style={textInput}>
              <View style={{ flexDirection: 'row' }}>
                <Text style={label}> Адрес дома <Text style={{ color: 'red' }}>*</Text></Text>
              </View>
              <TextInput
                style={inputMultiline}
                onChangeText={this.onChangeAddress.bind(this)}
                placeholder='Адрес.'
                autoCorrect={true}
                value={address}
                onEndEditing={() => this.onCheckAddress(address)}
                multiline={true}
                numberOfLines={1}
              />
              {badEnter[0] && <Text style={error}>{errorText[0]}</Text>}
            </View>
          </View>
          <View style={fixToText}>
            <View style={textInput}>
              <View style={{ flexDirection: 'row' }}>
                <Text style={label}> Количество квартир <Text style={{ color: 'red' }}>*</Text></Text>
              </View>
              <TextInput
                style={input}
                onChangeText={this.onChangeNumAppart.bind(this)}
                placeholder='Введите..'
                value={appartament}
                keyboardType='number-pad'
              />
              {badEnter[1] && <Text style={error}>{errorText[1]}</Text>}
            </View>
          </View>
          <View style={fixToText}>
            <View style={textInput}>
              <View style={{ flexDirection: 'row' }}>
                <Text style={label}> Количество этажей <Text style={{ color: 'red' }}>*</Text></Text>
              </View>
              <TextInput
                style={input}
                onChangeText={this.onChangeFloors.bind(this)}
                placeholder='Введите..'
                value={floors}
                keyboardType='number-pad'
              />
              {badEnter[2] && <Text style={error}>{errorText[2]}</Text>}
            </View>
          </View>
          <View style={fixToText}>
            <View style={textInput}>
              <View style={{ flexDirection: 'row' }}>
                <Text style={label}> Количество подъездов <Text style={{ color: 'red' }}>*</Text></Text>
              </View>
              <TextInput
                style={input}
                onChangeText={this.onChangePorches.bind(this)}
                placeholder='Введите..'
                value={porches}
                keyboardType='number-pad'
              />
              {badEnter[3] && <Text style={error}>{errorText[3]}</Text>}
            </View>
          </View>
          <View style={fixToText}>
            <View style={textInput}>
              <View style={{ flexDirection: 'row' }}>
                <Text style={label}> Год ввода в эксплуатацию <Text style={{ color: 'red' }}>*</Text></Text>
              </View>
              <TextInput
                style={input}
                onChangeText={this.onChangeYear.bind(this)}
                placeholder='Введите..'
                value={year}
                keyboardType='number-pad'
                autoCompleteType='cc-exp-year'
                onEndEditing={() => this.onCheckYear(year)}
              />
              {badEnter[4] && <Text style={error}>{errorText[4]}</Text>}
            </View>
          </View>
          <View style={fixToText}>
            <View style={textInput2}>
              <View style={{ flexDirection: 'row' }}>
                <Text style={label2}> Статус дома <Text style={{ color: 'red' }}>*</Text></Text>
              </View>
              <Dropdown
                data={dataStatus}
                onChangeText={this.onChangeStatus.bind(this)}
                value={status}
              />
              {badEnter[5] && <Text style={error}>{errorText[5]}</Text>}
              {/* placeholder='Выберите статус..' */}
            </View>
          </View>
        </View>

        <View style={{ alignItems: 'flex-end' }}>
          <View style={button}>
            <TouchableOpacity onPress={this.onSubmit.bind(this)} >
              <View style={buttonContainer}>
                <SvgXml
                  xml={save}
                  style={styles.iconMin} fill='#fff' />
                <Text style={buttonTitle}>Сохранить</Text>
              </View>
            </TouchableOpacity>
          </View>
        </View>
        <View style={{margin: 30}}><Text> </Text></View>
      </ScrollView>
    </View>

    );
  }

  private onPress() {
    this.setClearState();
    this.setState({ signup: !this.state.signup });
  }

  private onChangeAddress(address: string) {
    var badEnter = this.state.badEnter
    var errorText = this.state.errorText
    if (!address) {
      badEnter[0] = true;
      errorText[0] = 'Поле не заполнено!'
      this.setState({ badEnter, errorText, address, good: false });
      return;
    }
    badEnter[0] = false;
    this.setState({ address, badEnter, good: true });
  }
  private onCheckAddress(address: string) {
    var badEnter = this.state.badEnter
    var errorText = this.state.errorText
    if (address.length < 20) {
      badEnter[0] = true;
      errorText[0] = 'Введите полный адрес!'
      this.setState({ badEnter, errorText, address, good: false });
      return;
    }
    badEnter[0] = false;
    this.setState({ address, badEnter, good: true });
  }
  private onChangeNumAppart(appartament: string) {
    var badEnter = this.state.badEnter
    var errorText = this.state.errorText
    if (!appartament) {
      badEnter[1] = true;
      errorText[1] = 'Поле не заполнено!'
      this.setState({ badEnter, errorText, appartament, good: false });
      return;
    }
    var appart = parseInt(appartament, 10)
    if (appart != +appartament) {
      badEnter[1] = true;
      errorText[1] = 'Ввод только цифр!'
      this.setState({ badEnter, errorText, appartament, good: false });
      return;
    }
    if (appart < 10 || appart > 1000) {
      badEnter[1] = true;
      errorText[1] = 'Ограничение поля ввода: от 10 до 1000!'
      this.setState({ badEnter, errorText, appartament, good: false });
      return;
    }
    badEnter[1] = false;
    this.setState({ appartament, badEnter, good: true });

  }
  private onChangeFloors(floors: string) {
    var badEnter = this.state.badEnter
    var errorText = this.state.errorText
    if (!floors) {
      badEnter[2] = true;
      errorText[2] = 'Поле не заполнено!'
      this.setState({ badEnter, errorText, floors, good: false });
      return;
    }
    var num = parseInt(floors, 10)
    if (num != +floors) {
      badEnter[2] = true;
      errorText[2] = 'Ввод только цифр!'
      this.setState({ badEnter, errorText, floors, good: false });
      return;
    }
    if (num < 3 || num > 50) {
      badEnter[2] = true;
      errorText[2] = 'Ограничение поля ввода: от 3 до 50!'
      this.setState({ badEnter, errorText, floors, good: false });
      return;
    }
    badEnter[2] = false;
    this.setState({ floors, badEnter, good: true });
  }
  private onChangePorches(porches: string) {
    var badEnter = this.state.badEnter
    var errorText = this.state.errorText
    if (!porches) {
      badEnter[3] = true;
      errorText[3] = 'Поле не заполнено!'
      this.setState({ badEnter, errorText, porches, good: false });
      return;
    }
    var num = parseInt(porches, 10)
    if (num != +porches) {
      badEnter[3] = true;
      errorText[3] = 'Ввод только цифр!'
      this.setState({ badEnter, errorText, porches, good: false });
      return;
    }
    if (num < 1 || num > 10) {
      badEnter[3] = true;
      errorText[3] = 'Ограничение поля ввода: от 1 до 10!'
      this.setState({ badEnter, errorText, porches, good: false });
      return;
    }
    badEnter[3] = false;
    this.setState({ porches, badEnter, good: true });
  }
  private onChangeYear(year: string) {
    var badEnter = this.state.badEnter
    var errorText = this.state.errorText
    if (!year) {
      badEnter[4] = true;
      errorText[4] = 'Поле не заполнено!'
      this.setState({ badEnter, errorText, year, good: false });
      return;
    }
    var num = parseInt(year, 10)
    if (num != +year) {
      badEnter[4] = true;
      errorText[4] = 'Ввод только цифр!'
      this.setState({ badEnter, errorText, year, good: false });
      return;
    }   
    badEnter[4] = false;
    this.setState({ year, badEnter, good: true });
  }
  private onCheckYear(year: string) {
    var badEnter = this.state.badEnter
    var errorText = this.state.errorText
    var date = new Date().getFullYear()
    if (year.length < 4 || year.length > 4) {
      badEnter[4] = true;
      errorText[4] = 'Год должен иметь длину в 4 знака!'
      this.setState({ badEnter, errorText, good: false });
    } 
    if (+year > date) {
      badEnter[4] = true;
      errorText[4] = 'Год не может быть больше текущего!'
      this.setState({ badEnter, errorText, good: false });
    }
    else if (+year < 1950) {
      badEnter[4] = true;
      errorText[4] = 'Год не может быть меньше 1950!'
      this.setState({ badEnter, errorText, good: false });
    }
  }
  private onChangeStatus(status: string) {
    this.setState({ status });
  }


  private onSubmit() {
    const { address, appartament, floors, porches, year, status,
      badEnter, errorText, good } = this.state
    const { navigation } = this.props
    var $this = this;
    var obj, url, log: string, check = true;
    //if (signup) {

    if (!address) {
      badEnter[0] = true;
      errorText[0] = 'Поле не заполнено!'
      this.setState({ badEnter, errorText });
      check = false;
    }
    if (!appartament) {
      badEnter[1] = true;
      errorText[1] = 'Поле не заполнено!'
      this.setState({ badEnter, errorText });
      check = false;
    }
    if (!floors) {
      badEnter[2] = true;
      errorText[2] = 'Поле не заполнено!'
      this.setState({ badEnter, errorText });
      check = false;
    }
    if (!porches) {
      badEnter[3] = true;
      errorText[3] = 'Поле не заполнено!'
      this.setState({ badEnter, errorText });
      check = false;
    }
    if (!year) {
      badEnter[4] = true;
      errorText[4] = 'Поле не заполнено!'
      this.setState({ badEnter, errorText });
      check = false;
    }
    if (!status) {
      badEnter[5] = true;
      errorText[5] = 'Статус не выбран!'
      this.setState({ badEnter, errorText });
      check = false;
    }

    // }
    //else 
    if (check && good) {
      obj = {
        Admin: "0000e0000-t0t-00t0-t000-00000000000",
        Image: '5ddc6bd0-627b-42da-a603-d62adab55efe',
        Address: address,
        Appartaments: appartament,
        Floors: floors,
        Porches: porches,
        Year: year,
        Status: status == HomeStatus.Exploited ? 1 : 2
      }
      url = 'http://192.168.43.80:5000/api/home/create/';
      log = 'Добавить дом'


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
            // if (signup)
            //   $this.setClearState();
            // else
            navigation.goBack();
          }
          if (response.status == 500)
            console.log('Server Error', "Status: " + response.status + ' ' + response.json())
        })
        .then(function () {

        })
        .catch(error => {
          Alert.alert('Внимание', 'Ошибка ' + log + ' Post fetch: ' + error,
            [{ text: 'OK' }]);
        });
    }
  }
  private setClearState() {
    this.setState({
      appartament: '', address: '', floors: '', porches: '',
      year: '', status: '', colorT: '#000', colorPass: '#000',
      good: false, signup: false
    })
  }
}


const styles = StyleSheet.create({

  container: {
    borderColor: 'gray',
    borderWidth: 1,
    borderRadius: 10,
    margin: 10,
    paddingVertical: 5
  },
  icon: {
    width: 35,
    height: 35,
    marginRight: 10,
    borderRadius: 18,
  },
  textInput: {
    width: w * 0.9,
  },
  textInput2: {
    width: w * 0.85,
    //paddingHorizontal: 10
  },
  input: {
    height: 40,
    borderColor: 'gray',
    borderWidth: 1,
    borderRadius: 10,
    padding: 10,
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
    marginVertical: 10,
    flexDirection: 'row',
    justifyContent: 'center',
  },
  button: {
    marginTop: 30,
    width: 160,
    marginRight: 20
  },
  label: {
    marginTop: -10,
    marginBottom: 5,
    fontSize: 18,
    fontWeight: 'bold',
  },
  label2: {
    marginLeft: -8,
    marginBottom: -25,
    fontSize: 18,
    fontWeight: 'bold',
  },
  iconMin: {
    width: 20,
    height: 20,
    marginLeft: 20,
  },
  buttonContainer: {
    backgroundColor: '#15a009',
    height: 50,
    flexDirection: 'row',
    alignItems: 'center',
    borderRadius: 7
  },
  buttonTitle: {
    fontSize: 18,
    paddingLeft: 10,
    color: '#fff',
  },
  error: {
    marginTop: 5,
    color: 'red',
    marginBottom: -5,
    marginLeft: 5
  },
})
export { AddHomeScreen };