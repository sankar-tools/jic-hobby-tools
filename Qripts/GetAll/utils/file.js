const fs = require('path');
const fsu = require('fsu');

var file = {};

file.getUniquePath = getUniquePath

function getUniquePath(filePath, filename){
  let fileComponents = filename.split('.');
  let fileExt = fileComponents.pop();
  let fileWithoutExt = fileComponents.pop();

  let saveTo = `${filePath}/${fileWithoutExt}{_###}.${fileExt}`;

  console.log('SaveTo: ', saveTo);

  return fsu.createWriteStreamUnique(saveTo);
}

function generateFilePath(url, savePath, preservePath){

}

module.exports = file;
