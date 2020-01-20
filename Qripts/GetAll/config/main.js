module.exports = {
  input: {
    source: ''
  },
  fetch: {
    request: {
      header: {},
      redirect: {
        max: 10,
      }
    },
    domains: {
      ignore: ''
    }
  },
  save: {
    path: '',
    preservePath: 'true',
    autoIncrement: 'true',
    fileTyes: '',
    image: {
      min: {
        width: 2000,
        height: 2000,
        size: 100,000,
      }
    },

  },
}
