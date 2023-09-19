// @ts-nocheck
import { Box, Button, Paper, TextField } from '@mui/material'
import { MouseEventHandler, useState } from 'react'
import axios from 'axios'

function App() {
  const [id, setId] = useState('')
  const [action, setAction] = useState('')
  const [date, setDate] = useState('')
  const [email, setEmail] = useState('')
  const [ls, setLs] = useState('')
  const [itog, setItog] = useState('')
  const [name, setName] = useState('')
  const [otvet, setOtvet] = useState(false)
  const [textOtvet, setTextOtvet] = useState({})
  // {
  //   "PAY_ID": "e05acc96-1949-741b-a002-30e901fda8fa",
  //   "PAY_ACTION": "REG",
  //   "PAY_DATE": "2020-01-30 10:16:27",
  //   "PAY_EMAIL": "",
  //   "PAY_LS": "724144",
  //   "PAY_ITOG":"17359",
  //   "PAY_NAME": "Оплата водопотребления л/с 724144"
  // }

  const handleSubmit: MouseEventHandler<HTMLButtonElement> = (e) => {
    e.preventDefault()
    if (!id || !action || !date || !email || !ls || !itog || !name) return
    const REQ = {
      PAY_ID: id,
      PAY_ACTION: action,
      PAY_DATE: date,
      PAY_EMAIL: email,
      PAY_LS: ls,
      PAY_ITOG: itog,
      PAY_NAME: name,
    }

    console.log(`${JSON.stringify(REQ)}`)
    axios
      .get(`https://pay.pay-ok.org/demo/?REQ=${JSON.stringify(REQ)}`)
      .then((response) => console.log(response))
  }

  const handleGet = () => {
    axios
      .get(
        `https://pay.pay-ok.org/demo/?REQ={"PAY_ID":"${id}","PAY_ACTION":"GET_INFO"}`,
      )
      .then((response) => {
        const otvet = JSON.parse(JSON.stringify(response.data))
        setOtvet(true)
        otvet.STATUS.params.OD_PARAMS = JSON.parse(
          JSON.parse(JSON.stringify(response.data.STATUS.params.OD_PARAMS)),
        )
        setTextOtvet(otvet.STATUS.params)
        console.log(otvet)
      })
  }

  return (
    <Box display={'flex'}>
      <Box>
        <Paper
          sx={{
            width: 400,
            padding: 3,
          }}
          elevation={10}
        >
          <form
            style={{
              rowGap: 20,
              display: 'flex',
              flexDirection: 'column',
            }}
          >
            <TextField
              label={'PayId'}
              required
              value={id}
              onChange={({ target: { value } }) => setId(value)}
            />
            <TextField
              label={'PayAction'}
              required
              value={action}
              onChange={({ target: { value } }) => setAction(value)}
            />
            <input
              type="date"
              value={date}
              onChange={({ target: { value } }) => setDate(value)}
            />
            <TextField
              label={'PayEmail'}
              required
              value={email}
              onChange={({ target: { value } }) => setEmail(value)}
            />
            <TextField
              label={'PayLs'}
              required
              value={ls}
              onChange={({ target: { value } }) => setLs(value)}
            />
            <TextField
              label={'PayItog'}
              required
              value={itog}
              onChange={({ target: { value } }) => setItog(value)}
            />
            <TextField
              label={'PayName'}
              required
              value={name}
              onChange={({ target: { value } }) => setName(value)}
            />
            <Button
              onClick={handleSubmit}
              variant={'contained'}
              type={'submit'}
            >
              Отправить
            </Button>
          </form>
        </Paper>
        <Paper
          elevation={12}
          sx={{
            width: 400,
            padding: 3,
          }}
        >
          <Button onClick={handleGet}>Получить</Button>
        </Paper>
      </Box>
      {otvet && textOtvet && (
        <Box>
          <p>Id : {textOtvet.OD_PARAMS.id}</p>
          <table className="bill-details">
            <tbody>
              <tr>
                <td>
                  Дата : <span>{textOtvet.OD_TIMESTAMP.slice(0, 10)}</span>
                </td>
                <td>
                  Время : <span>{textOtvet.OD_TIMESTAMP.slice(10)}</span>
                </td>
              </tr>
              <tr>
                <td>
                  Личный счет:
                  <span> {textOtvet.lsc}</span>
                </td>
                <td>
                  Почта : <span>{textOtvet.contacts}</span>
                </td>
              </tr>
              <tr>
                <td>
                  Фискальный номер:
                  <span> {textOtvet.OD_PARAMS.fsNumber}</span>
                </td>
                <td>
                  ОФД:{' '}
                  <span>
                    {textOtvet.OD_PARAMS.ofdName}(
                    {textOtvet.OD_PARAMS.ofdWebsite})
                  </span>
                </td>
              </tr>
              <tr>
                <th className="center-align" colSpan={2}>
                  <span className="receipt">Фискальный чек</span>
                </th>
              </tr>
              <tr>
                <th className="center-align" colSpan={2}>
                  <span className="receipt">
                    СМЕНА №{textOtvet.OD_PARAMS.shiftNumber} ЧЕК №
                    {textOtvet.OD_PARAMS.documentIndex} ФД №
                    {textOtvet.OD_PARAMS.documentNumber}
                  </span>
                </th>
              </tr>
            </tbody>
          </table>

          <table className="items">
            <thead>
              <tr>
                <th className="heading name">Товар</th>
                <th className="heading qty">Кол-во</th>
                <th className="heading rate">Цена</th>
              </tr>
            </thead>

            <tbody>
              <tr>
                <td>
                  {textOtvet.positions.slice(
                    textOtvet.positions.indexOf('s:57:"') + 6,
                    -4,
                  )}
                </td>
                <td>
                  {textOtvet.positions.slice(
                    textOtvet.positions.indexOf('PAY_COUNT') + 13,
                    textOtvet.positions.indexOf('PAY_COUNT') + 14,
                  )}
                </td>
                <td className="price">
                  {textOtvet.positions.slice(
                    textOtvet.positions.indexOf('PAY_PRICE') + 13,
                    textOtvet.positions.indexOf('PAY_PRICE') + 19,
                  )}
                </td>
              </tr>
              <tr>
                <th colSpan={2} className="total text">
                  Total
                </th>
                <th className="total price">
                  {textOtvet.positions.slice(
                    textOtvet.positions.indexOf('PAY_PRICE') + 13,
                    textOtvet.positions.indexOf('PAY_PRICE') + 19,
                  )}
                </th>
              </tr>
            </tbody>
          </table>
          <section>
            <p>
              Paid by : <span>CASH</span>
            </p>
          </section>
        </Box>
      )}
    </Box>
  )
}

export default App
