﻿using BCrypt.Net;
using System.ComponentModel.DataAnnotations;

namespace ViceriWebApi.Models
{
    public class Usuario
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage = "Preencha seu Nome corretamente")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Preencha o Email corretamente")]
        public string Email { get; set; }

        private string _Senha;
        [Required(ErrorMessage = "Preencha a Senha corretamente")]
        public string Senha
        {
            get { return _Senha; }
            set
            {

                if (string.IsNullOrWhiteSpace(value))
                    _Senha = value;
                else
                    _Senha = BCrypt.Net.BCrypt.HashPassword(value);
            }
        }
        [Required(ErrorMessage = "Preencha o CPF corretamente")]
        public string CPF { get; set; }
        [Required(ErrorMessage = "Preencha sua Data de Nascimento corretamente")]
        public DateTime DataNascimento { get; set; }
    }
}
