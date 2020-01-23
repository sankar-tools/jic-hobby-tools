mainConfig = require('./config/main');

__rootDir = __dirname;

logger = require('./utils/logger');
logger.banner(
  "Qricks - GetAll \n\
  Ver: 1.0.0"
);

const fs = require('fs');
const path = require('path');

let lineCount = 1;

console.log('Save to ', mainConfig.save.path)

var lines = require('fs').readFileSync(mainConfig.input.source, 'utf-8')
  .split('\r\n')
  .filter(Boolean);

require('./download')(lines)
