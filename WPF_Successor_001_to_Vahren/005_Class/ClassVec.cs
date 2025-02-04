﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_Successor_001_to_Vahren._005_Class
{
    public class ClassVec
    {
        public double X { get; set; }
        public double Y { get; set; }

        private int _speed;

        public int Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        private Point _centerPoint;

        public Point CenterPoint
        {
            get { return _centerPoint; }
            set { _centerPoint = value; }
        }
        private Point _target;

        public Point Target
        {
            get { return _target; }
            set { _target = value; }
        }

        private Point _vec;

        public Point Vec
        {
            get { return _vec; }
            set { _vec = value; }
        }

        public void Set()
        {
            var calc0 = ReturnVecDistance(from: new Point(this.X, this.Y), to: Target);
            this.Vec = ReturnNormalize(calc0);
        }

        public void Move()
        {
            this.X = X + (this.Vec.X * this.Speed);
            this.Y = Y + (this.Vec.Y * this.Speed);
        }

        public Point Get(Point targetFrom)
        {
            double xMove = (this.Vec.X * this.Speed);
            double yMove = (this.Vec.Y * this.Speed);
            double resultX = 0;
            double resultY = 0;
            if (Target.X > this.CenterPoint.X)
            {
                resultX = targetFrom.X - xMove;
            }
            else
            {
                resultX = targetFrom.X + xMove;
            }

            if (Target.Y > this.CenterPoint.Y)
            {
                resultY = targetFrom.Y - yMove;
            }
            else
            {
                resultY = targetFrom.Y + yMove;
            }
            return new Point(resultX, resultY);
        }

        public Point ReturnVecDistance(Point from, Point to)
        {
            Point re = new Point();
            re.X = to.X - from.X;
            re.Y = to.Y - from.Y;
            return re;
        }
        public Point ReturnNormalize(Point target)
        {
            var result = target;
            var calc = Math.Sqrt(target.X * target.X + target.Y * target.Y);
            if (calc > 0)
            {
                var reciprocal = 1 / calc;
                result.X *= reciprocal;
                result.Y *= reciprocal;
            }
            return result;
        }
    }
}
