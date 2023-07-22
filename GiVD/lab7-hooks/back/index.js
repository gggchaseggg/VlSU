const goods = require('./data.json')
const express = require('express')
const app = express()
const PORT = 3001

app.get('/', (request, response) => {
  const page = parseInt(request.query.page)
  const count = parseInt(request.query.count)

  const responseBody = {
    total_count: goods.length
  }

  if (page && count) {
    const firstIndex = (page - 1) * count
    const endIndex = firstIndex + count
    responseBody.items = goods.slice(firstIndex, endIndex)
    response.send(responseBody)
  } else {
    response.status(400).send('Bad Request')
  }
})

app.listen(PORT,() => {
  console.log(`Back listening on port ${PORT}`)
})
