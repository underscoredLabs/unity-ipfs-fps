mergeInto(LibraryManager.library, {
  GetWalletAddress: function () {
    if (window.web3) {
      var returnStr = web3.currentProvider.selectedAddress;
      if (returnStr === null) {
        returnStr = "null";
      }
      var bufferSize = lengthBytesUTF8(returnStr) + 1;
      var buffer = _malloc(bufferSize);
      stringToUTF8(returnStr, buffer, bufferSize);
      return buffer;
    } else {
      var returnStr = "null"
      var bufferSize = lengthBytesUTF8(returnStr) + 1;
      var buffer = _malloc(bufferSize);
      stringToUTF8(returnStr, buffer, bufferSize);
      return buffer;
    }
  },
});
