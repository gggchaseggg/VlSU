import { FC } from 'react'
import { TableCellProps } from '../Table/TableCell.types'

const TableCell: FC<TableCellProps> = ({ text }) => {
  return (
    <td width={30} height={30}>
      {text}
    </td>
  )
}

export default TableCell
