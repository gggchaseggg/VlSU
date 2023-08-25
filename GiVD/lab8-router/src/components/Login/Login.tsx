import { useContext, useState } from 'react'
import { LoginContext } from '../../context'

const Login = () => {
  const [name, setName] = useState('')
  const [password, setPassword] = useState('')
  const setIsLogin = useContext(LoginContext)

  const handleSubmit = () => {
    if (name === 'admin' && password === 'password') {
      setIsLogin(true)
      console.log('you are in')
    } else {
      console.log('just fail login')
    }
  }

  return (
    <>
      <h1>Login</h1>
      <input
        type="text"
        value={name}
        onChange={({ target: { value } }) => setName(value)}
      />
      <input
        type="password"
        value={password}
        onChange={({ target: { value } }) => setPassword(value)}
      />
      <button onClick={handleSubmit}>submit</button>
    </>
  )
}

export default Login
