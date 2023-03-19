class PasswordCryptography {
  static EncryptMessage(plainText, password) {
      const passwordSum = PasswordCryptography.GetPasswordSize(password);

      let utf8Encode = new TextEncoder();
      const arr = utf8Encode.encode(plainText);

      let cipherText = "";
      arr.forEach(byte => {
          cipherText += (byte + passwordSum) + " ";
      })

      return cipherText.slice(0,-1);
  }

  static DecryptMessage(cipherText, password) {
      const cipherTextArr = cipherText.trim().split(' ')
      const passwordSum = PasswordCryptography.GetPasswordSize(password);

      let plainText = "";
      cipherTextArr.forEach((element) => {
          plainText += String.fromCharCode(element - passwordSum);
      });
      return plainText;
  }

  static GetPasswordSize(password) {
      let utf8Encode = new TextEncoder();
      const arr = utf8Encode.encode(password);

      let passwordSum = 0;
      arr.forEach(byte => {
          passwordSum += byte;
      })

      return passwordSum;
  }
}

module.exports = PasswordCryptography;