using UnityEngine;
using UnityEngine.UI;

namespace NPC_Interaction.UI {
    public class UI_FlexibleGridSystem : LayoutGroup {
        public enum FitType {
            Uniform,
            Width,
            Height,
            FixedRows,
            FixedColumns,
        }
        public int _rows;
        public int _columns;
        public Vector2 _cellSize;
        public Vector2 _spacing;
        public FitType _fitType;
        public bool _fitX;
        public bool _fitY;
        public override void CalculateLayoutInputHorizontal() {
            base.CalculateLayoutInputHorizontal();

            if (_fitType == FitType.Width || _fitType == FitType.Height || _fitType == FitType.Uniform) {
                _fitX = true;
                _fitY = true;
                float sqrt = Mathf.Sqrt(transform.childCount);
                _rows = Mathf.CeilToInt(sqrt);
                _columns = Mathf.CeilToInt(sqrt);
            }


            if (_fitType == FitType.Width || _fitType == FitType.FixedColumns) {
                _rows = Mathf.CeilToInt(transform.childCount / (float)_columns);
            } else if (_fitType == FitType.Height || _fitType == FitType.FixedRows) {
                _columns = Mathf.CeilToInt(transform.childCount / (float)_rows);
            }

            float parentWidth = rectTransform.rect.width;
            float parentHeight = rectTransform.rect.height;

            float cellWidth = (parentWidth / (float)_columns) - ((_spacing.x / (float)_columns) * (_columns - 1)) - (padding.left / (float)_columns) - (padding.right / (float)_columns);
            float cellHeight = (parentHeight / (float)_rows) - ((_spacing.y / (float)_columns) * (_columns - 1)) - (padding.top / (float)_rows) - (padding.bottom / (float)_rows);

            _cellSize.x = _fitX ? cellWidth : _cellSize.x;
            _cellSize.y = _fitY ? cellHeight : _cellSize.y;

            int colCount = 0;
            int rowCount = 0;

            for (int i = 0; i < rectChildren.Count; i++) {
                rowCount = i / _columns;
                colCount = i % _columns;

                var item = rectChildren[i];

                var xPos = (_cellSize.x * colCount) + (_spacing.x * colCount) + padding.left;
                var yPos = (_cellSize.y * rowCount) + (_spacing.y * rowCount) + padding.top;

                SetChildAlongAxis(item, 0, xPos, _cellSize.x);
                SetChildAlongAxis(item, 1, yPos, _cellSize.y);


            }
        }
        public override void CalculateLayoutInputVertical() {
        }

        public override void SetLayoutHorizontal() {
        }

        public override void SetLayoutVertical() {
        }
    }
}
