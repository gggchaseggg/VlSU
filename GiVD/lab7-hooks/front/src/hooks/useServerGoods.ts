import { useEffect, useState } from 'react'

type Item = {
  id: number
  name: string
  manufactureDate: Date
  price: number
}

type Goods = {
  items: Item[]
  paging: {
    page: number
    rowsPerPage: number
    total: number
  }
}

export const useServerGoods = (initialPage = 1, initialCount = 10) => {
  const [loading, setLoading] = useState(false)
  const [page, setPage] = useState(initialPage)
  const [count, setCount] = useState(initialCount)
  const [error, setError] = useState(false)
  const [data, setData] = useState<Goods | null>(null)

  useEffect(() => {
    setLoading(true)
    fetch(`http://localhost:3001/?page=${page}&count=${count}`)
      .then((response) => response.json())
      .then((data) => setData(data))
      .catch(() => setError(true))
      .finally(() => setLoading(false))
  }, [page, count])

  return {
    loading,
    data,
    error,
    page,
    count,
    setPage,
    setCount,
  }
}
