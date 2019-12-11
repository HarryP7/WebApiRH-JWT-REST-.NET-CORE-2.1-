using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiRH.Models
{
    public enum HomeStatus
    {
        Exploited = 1,  //Эксплуатируемый
        Emergency       //Аварийный
    }
}