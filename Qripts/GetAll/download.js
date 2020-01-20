'use strict'

const Fs = require('fs')
const Path = require('path')
const Axios = require('axios')
const ProgressBar = require('progress')

async function downloadImage (url) {
  // const url =

  const { data, headers } = await Axios({
    url,
    method: 'GET',
    responseType: 'stream'
  })
  const totalLength = headers['content-length']

  console.log(`\n\n${url} =>`)
  const progressBar = new ProgressBar('->[:bar] :percent :etas', {
      width: 40,
      complete: '=',
      incomplete: ' ',
      renderThrottle: 1,
      total: parseInt(totalLength)
    })

  const writer = getDownloadStream(url)
  data.on('data', (chunk) => progressBar.tick(chunk.length))
  data.pipe(writer)
}

module.exports = downloadImage;

function getDownloadStream(url){
  let fileComponents = filename.split('.');
  let fileExt = fileComponents.pop();
  let fileWithoutExt = fileComponents.pop();

  let saveTo = `${filePath}/${fileWithoutExt}{_###}.${fileExt}`;

  console.log(saveTo);

  return fsu.createWriteStreamUnique(saveTo, { force: true });
}

function generateFilePath(url){
  let urlMain = url.split('://').pop()
  let urlComponents = urlMain.split('/');
  let fileComponents = urlComponents.pop().split('.');
  let fileExt = fileComponents.pop();
  let fileWithoutExt = fileComponents.pop();


}
