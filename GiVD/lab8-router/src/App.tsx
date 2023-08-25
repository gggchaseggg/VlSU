import { BrowserRouter, Link, Route, Routes } from 'react-router-dom'
import { Login, Main, Welcome } from './components'
import { useState } from 'react'
import { LoginContextProvider } from './context'

function App() {
  const [isLogin, setIsLogin] = useState(false)
  return (
    <LoginContextProvider value={setIsLogin}>
      <BrowserRouter>
        <ul>
          <li>
            <Link to={'/'}>Main</Link>
          </li>
          <li>
            <Link to={'/login'}>Login</Link>
          </li>
          {isLogin && (
            <li>
              <Link to={'/welcome'}>Welcome</Link>
            </li>
          )}
        </ul>
        <Routes>
          <Route index element={<Main />} />
          <Route path={'login'} element={<Login />} />
          {isLogin && <Route path={'welcome'} element={<Welcome />} />}
          <Route path={'*'} element={<Main />} />
        </Routes>
      </BrowserRouter>
    </LoginContextProvider>
  )
}

export default App
