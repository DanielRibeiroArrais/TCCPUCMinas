$(document).ready(function () {
    $(".telefone").inputmask({ mask: ["(99) 9999-9999", "(99) 99999-9999",], keepStatic: true });
    $(".CpfCnpj").inputmask({ mask: ["999.999.999-99", "99.999.999/9999-99",], keepStatic: true });
    $(".cep").inputmask("mask", { "mask": "99999-999" });
    $(".cpf").inputmask("mask", { "mask": "999.999.999-99" }, { reverse: true });
    $("#CNPJ").inputmask("mask", { "mask": "99.999.999/9999-99" }, { reverse: true });
    $(".data").inputmask("mask", { "mask": "99/99/9999" });
    $(".dataHora").inputmask("mask", { "mask": "99/99/9999 99:99" });
});