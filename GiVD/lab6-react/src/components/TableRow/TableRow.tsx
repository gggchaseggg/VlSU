import { FC } from 'react'
import { TableRowProps } from './TableRow.types'
import { TableCell } from '../TableCell'

const TableRow: FC<TableRowProps> = ({ row }) => {
  return (
    <tr>
      {row.map((item) => (
        <TableCell text={item} />
      ))}
    </tr>
  )
}

export default TableRow
