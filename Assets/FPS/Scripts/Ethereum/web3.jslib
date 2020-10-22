// https://github.com/Nethereum/Nethereum.Flappy#webgl-andmetamask
mergeInto(LibraryManager.library, {
  GetWalletAddress: function () {
    var returnStr = web3.currentProvider.selectedAddress;
    if (returnStr === null) {
      returnStr = "null"
    };
    var bufferSize = lengthBytesUTF8(returnStr) + 1;
    var buffer = _malloc(bufferSize);
    stringToUTF8(returnStr, buffer, bufferSize);
    return buffer;
  },
});
