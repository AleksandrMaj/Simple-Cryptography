const express = require("express");
const PasswordCryptography = require("./PasswordCryptography");
const app = express();
const port = 5000;

app.get("/encrypt/:message/:password", (req, res) => {
    const message = req.params.message;
    const password = req.params.password;

    const cipherText = PasswordCryptography.EncryptMessage(message, password);
    res.send(cipherText);
});

app.get("/decrypt/:message/:password", (req, res) => {
    const message = req.params.message;
    const password = req.params.password;

    const plainText = PasswordCryptography.DecryptMessage(message, password);
    res.send(plainText);
});

app.listen(port, () => {
    console.log(`Example app listening on port ${port}`);
});

console.log(`Node.js web server at port ${port} is running`);