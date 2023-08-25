import { createContext, Dispatch, SetStateAction } from 'react'

export const LoginContext = createContext<Dispatch<SetStateAction<boolean>>>(
  () => {},
)

export const LoginContextProvider = LoginContext.Provider
