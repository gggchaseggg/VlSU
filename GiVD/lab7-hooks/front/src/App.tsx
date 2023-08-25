import { useServerGoods } from './hooks/useServerGoods'
import { DataGrid, GridColDef, GridPaginationModel } from '@mui/x-data-grid'
import { useState } from 'react'

function App() {
  const { error, loading, data, page, count, setCount, setPage } =
    useServerGoods()

  const [columns] = useState<GridColDef[]>([
    { field: 'id', headerName: 'ID', width: 20 },
    { field: 'name', headerName: 'Название', width: 500 },
    {
      field: 'manufactureDate',
      headerName: 'Дата производства',
      width: 200,
    },
    { field: 'price', headerName: 'Цена', width: 200 },
  ])

  const handlePageChange = (model: GridPaginationModel) => {
    setCount(model.pageSize)
    setPage(model.page + 1)
  }

  if (loading) {
    return <h2>Загрузка</h2>
  }

  if (error) {
    return <h2>Ошибка соединения</h2>
  }

  return (
    <div style={{ width: 960 }}>
      {data && (
        <DataGrid
          columns={columns}
          rows={data.items}
          autoHeight
          initialState={{
            pagination: {
              paginationModel: {
                pageSize: 10,
                page: 0,
              },
            },
          }}
          paginationMode={'server'}
          paginationModel={{
            page: page - 1,
            pageSize: count,
          }}
          rowCount={data.paging.total}
          pageSizeOptions={[5, 10, 25]}
          onPaginationModelChange={handlePageChange}
        />
      )}
    </div>
  )
}

export default App
